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
Install helm charts

```
helm install cronjob/ --generate-name

folder structure: 

output:
NAME: cronjob-1651582645
LAST DEPLOYED: Tue May  3 18:27:25 2022
NAMESPACE: default
STATUS: deployed
REVISION: 1
TEST SUITE: None
```


List helm charts
```
helm ls
```
Uninstall a release
```
helm uninstall <releasename> 

eg: helm uninstall cronjobhelm-1651568412
```

