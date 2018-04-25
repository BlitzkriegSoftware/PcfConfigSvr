#!/bin/bash
set +x
cf create-service p-config-server standard dev-config-server -c "{\"count\":1,\"git\":{\"cloneOnStart\":\"true\",\"uri\":\"https://github.com/BlitzkriegSoftware/pcflabconfig\"}}"