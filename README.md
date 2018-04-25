# PcfConfigSvr #

Creating and using PCF Config Server from .NET Core and NodeJS

## Introduction ##

PCF Configuration Server is the preferred option to externalizing configuration following the patterns in the <a href="http://12factor.net" target="_blank">http://12factor.net</a>. The alternative User-Provided-Services is also good and covered in another repo.

### References ### 

* <a href="https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/" target="_blank">https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/</a>
* <a href="https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/configuring-with-git.html" target="_blank">https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/configuring-with-git.html</a>
* <a href="https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/background-information.html" target="_blank">https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/background-information.html</a>

## Creating Configuration Server (CS) ##

There is a folder called `scripts` that has two prototypical scripts for creating and deleting an instance of Configuration Server (CS) in the current ORG and SPACE. These were testing on <a href="https://api.run.pivotal.io" target="_blank">https://api.run.pivotal.io</a>, you may need to make changes if you are running on another PCF install.

## Configuring Configuration Server ##

The easiest way to provide name/value pairs for CS to serve up to applications is to create a GIT repo with either YAML or Properties files (we are using YAML for the demo).

See: <a href="https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/configuring-with-git.html" target="_blank">https://docs.pivotal.io/spring-cloud-services/1-4/common/config-server/configuring-with-git.html</a>

By default the demo script creates a CS instance using my GITHUB configuration <a href="https://github.com/BlitzkriegSoftware/pcflabconfig" target="_blank">https://github.com/BlitzkriegSoftware/pcflabconfig</a> which you can use as an example.

## Demos ## 

We have two demos one in .NET Core, and the other in NodeJS

### Introduction ###

Make sure your configuration server is up and going in PCF.

Finding the CS from code. The easiest way to do this is to bind to the service in your Manifest and read and parse the VCAP_SERVICES environment variable.

### Running Locally ###

You will need to:

1. Edit the file `vcap_services_example.json` to put in your settings which you can get from the PCF web dashboard
2. Copy the file into each demo folder as `vcap_services.json`
3. Then the demos will run locally using this file

### .NET Core ###

To query the config server in .NET Core we use:
* System.Net.Http, HttpClient
* Newtonsoft.Json, JObject

So we use the HttpClient to do the requests, grab the text and parse them as JObjects. 

When running this Web API 2 demo, browse to your URL plus `/swagger` to be able to play with the API.

I use Visual Studio 2017 to edit .NET projects

### NodeJS ###

To query the config server in NodeJS we use the NPM libraries: 
* request
* request-promises

The promises add-on makes request a lot more friendly. 

We parse the config on start up, and then propagate it a Global (yes, ugly) for simplicity.

This example is a small web app that shows the results in a table on the home page.

I use Visual Studio Code to edit NodeJS projects. It's handy to have the NodeJS plug-ins loaded.

## About me ##

**Stuart Williams**

* Cloud/DevOps Practice Lead + National Markets Consultant
* <a href="http://magenic.com" target="_blank">Magenic Technologies</a>
* <a href="mailto:stuartw@magenic.com" target="_blank">stuartw@magenic.com</a> (e-mail)
* Blog: <a href="http://blitzkriegsoftware.net/Blog" target="_blank">http://blitzkriegsoftware.net/Blog</a>
* LinkedIn: <a href="http://lnkd.in/P35kVT" target="_blank">http://lnkd.in/P35kVT</a>
* YouTube: <a href="https://www.youtube.com/channel/UCO88zFRJMTrAZZbYzhvAlMg" target="_blank">https://www.youtube.com/channel/UCO88zFRJMTrAZZbYzhvAlMg</a> 