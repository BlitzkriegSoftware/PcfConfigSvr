/**
 * PCF Configuration Server (CS) Helper
 */

// The actual configuration

var appName = 'csnodejs';

var rp = require('request-promise');

var fs = require("fs");
var path = require("path");

var cs = serverConfig();

function serverConfig() {
    var vcap_services = process.env.VCAP_SERVICES

    if (!vcap_services) {
        var serviceFile = path.join(global.WebRoot, 'vcap_services.json');
        var vcap_services = fs.readFileSync(serviceFile, 'UTF8');
    }

    console.log("VCAP_SERVICES:\n" + vcap_services);

    vcap_services = JSON.parse(vcap_services);

    var creds = eachRecursive( vcap_services, "access_token_uri" );

    var cs = {
        access_token_uri: creds.access_token_uri,
        client_id: creds.client_id,
        client_secret: creds.client_secret,
        uri: creds.uri
    };

    return cs;
}

// search the object tree for an object that has a named property
function eachRecursive(obj, hasThisProperty)
{
    for (var k in obj)
    {
        var value = obj[k];
        if (typeof value == "object" && value !== null) {
            if (value.hasOwnProperty(hasThisProperty)) { 
                return value;
            }
            return eachRecursive(value, hasThisProperty);
        }
        
    }
}

function parseConfig(tokenJson) {
    var configData = [];

    if (tokenJson) {
        tokenJson = JSON.parse(tokenJson);
        tokenJson.propertySources.forEach(element => {
            var uc = element.source;
            Object.keys(uc).map(function (objectKey, index) {
                var value = uc[objectKey];
                var item = {};
                item.name = objectKey;
                item.value = value;
                configData.push(item);
            });
        });
    }

    return configData;
}

function getConfigWithKey() {

    var options = {
        method: 'POST',
        uri: cs.access_token_uri,
        timeout: 5000,
        form: {
            grant_type: 'client_credentials'
        },
        timeout: 5000,
        auth: {
            'user': cs.client_id,
            'pass': cs.client_secret,
            'sendImmediately': true
        }
    };

    rp(options)
        .then(function (body) {
            var bodyJson = JSON.parse(body);
            var token = bodyJson.access_token;

            var options2 = {
                method: 'GET',
                uri: cs.uri + '/' + appName + '/development',
                timeout: 5000,
                auth: {
                    'user': null,
                    'pass': null,
                    'sendImmediately': true,
                    'bearer': token
                }
            };

            rp(options2)
                .then(function (body) {
                    global.AppConfig = parseConfig(body);
                })
                .catch(function (err) {
                    throw new Error(err);
                });
        })
        .catch(function (err) {
            throw new Error(err);
        });
}

module.exports = function() {
    return getConfigWithKey();
}