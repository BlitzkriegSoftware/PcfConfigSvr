#!/bin/bash
set +x

TMPFILE=temp.txt
OUTFILE=configuration.json

printf  "\nConfiguration: $OUTFILE\n"

# URL to the Config Server
URL={URL configuration server}

# UAA Configuration 
ACCESS_TOKEN_URI={URL to UAA Server}
CLIENT_ID={Client Id}
CLIENT_SECRET={Client Secret}

# Application
APP=csnodejs
# APP=csdotnet

# Get UAA Token
curl -s -k $ACCESS_TOKEN_URIS -u $CLIENT_ID:$CLIENT_SECRET -d grant_type=client_credentials $ACCESS_TOKEN_URI | jq -r .access_token > $TMPFILE
TOKEN=$(<$TMPFILE)
rm $TMPFILE

# Use UAA Token to get configuration from server
curl -s -k -H "Authorization: bearer $TOKEN" -H "Accept: application/json" $URL/$APP/development | tee $OUTFILE