#### Deploy Cron jobs in kubernetes cluster.. 

In this example, I have used mail server to send a mail for every 1 min as a Job

Below is the yml file, bit straight forward. much easy to understand

```
apiVersion: batch/v1
kind: CronJob
metadata:
  name: sendmail
spec:
  suspend: true  # flag used to suspend the job (true/false)
  schedule: "* * * * *"  //Runs every 1 min
  jobTemplate:
    spec:
      template:
        spec:
          containers:
          - name: sendmail
            image: vijaychamp/cronsendmail:0.0.3 //a .net core console application image with .net core runtime
            imagePullPolicy: IfNotPresent
            #command:
            #- /bin/sh
            #- -c
            #- date; echo Hello from the Kubernetes cluster
          restartPolicy: OnFailure

```

See cron jon status and logs

```
kubectl get cronjob sendmail
kubectl get jobs --watch

pods=$(kubectl get pods --selector=job-name=sendmail-4111706356 --output=jsonpath={.items[*].metadata.name})
kubectl logs $pods
```

Suspend corn job
```
kubectl patch cronjobs sendmail -p '{"spec" : {"suspend" : true }}'
if above command not working, then change the yml file suspend to true and vice versa for running again
spec:
  suspend: true

```

If you dont want to run this job, use below command to delete it.

```
kubectl delete cronjob sendmail
```

