### HELM Chart for CRON Job deployment

Standard helm chart creation command will give you comprehensive options as below 

Command to create a chart
```
helm create CronJobHelm
```
Output as below 



So, for now I dont want to try with all those options, just I will focus on deploying cronjon with helm template

##### Check the correctness of the helm chart
```
helm lint <ChartName>
```
![image](https://user-images.githubusercontent.com/49226342/166459325-6de9b7d7-d1c6-47e6-ab59-5b945b6a4f85.png)


Install helm charts

```
helm install cronjob/ --generate-name 
```
output:
![image](https://user-images.githubusercontent.com/49226342/166458811-03e7c70b-0ce0-49d6-8747-a95eb5c04296.png)


List helm charts
```
helm ls
```
![image](https://user-images.githubusercontent.com/49226342/166458679-dc9bc708-0e3c-46c1-9453-814dbb1d8710.png)

Uninstall a release
```
helm uninstall <releasename> 

eg: helm uninstall cronjob-1651582960
```

