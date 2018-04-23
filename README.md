# PcfConfigSvr #

Using PCF Config Server from .NET Core and NodeJS

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


## Demos ## 

We have two demos one in .NET Core, and the other in NodeJS

### Introduction ###

Make sure your configuration server is up and going in PCF.

Finding the CS from code. The easiest way to do this is to bind to the service in your Manifest and read and parse the VCAP_SERVICES environment variable.


### .NET Core ###




### NodeJS ###

To query the config server in NodeJS we use the library: <a href="https://www.npmjs.com/package/node-cloud-config-client" target="_blank">https://www.npmjs.com/package/node-cloud-config-client</a>





## About me ##

**Stuart Williams**

* Cloud/DevOps Practice Lead + National Markets Consultant
* <a href="http://magenic.com" target="_blank">Magenic Technologies</a>
* <a href="mailto:stuartw@magenic.com" target="_blank">stuartw@magenic.com</a> (e-mail)
* Blog: <a href="http://blitzkriegsoftware.net/Blog" target="_blank">http://blitzkriegsoftware.net/Blog</a>
* LinkedIn: <a href="http://lnkd.in/P35kVT" target="_blank">http://lnkd.in/P35kVT</a>
* YouTube: <a href="https://www.youtube.com/channel/UCO88zFRJMTrAZZbYzhvAlMg" target="_blank">https://www.youtube.com/channel/UCO88zFRJMTrAZZbYzhvAlMg</a> 