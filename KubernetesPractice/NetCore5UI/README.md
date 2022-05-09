
### Connecting frontend application to backend application 

I have created Asp.net core UI and ASP.net core API projects, Idea is to test the connection between them

I have an /home controller returns node/env details that should be shown ui project

Below are the updates I have done to achieve this 

1. Changing Yaml files [API Yaml](https://github.com/vijaymarada/Docker-Kubernetes/blob/main/KubernetesPractice/NetCore5API/kubernetesDeployment.yml)
    Few points to focus
    i. Label names
    ii. Selector section in service and deployment
    
2. Chaging the API end point
    Prevoiusly I have tested with localhost:XXXX  with port number, but that does't working, since both UI and API's are running in side the cluster.
    I have tried as below in [app settings](https://github.com/vijaymarada/Docker-Kubernetes/blob/main/KubernetesPractice/NetCore5UI/appsettings.json) file
    ```
    "API": "http://host.docker.internal:32138/Home        //home is a controller return few cluster related details
    ```
    And its working. Though, I am not sure this is the right way ot not, still exploring and will update accrodingly. 
    
    Yes, Here is the update: Instead of mentioning **host.docker.internal** We can **describe** the **api service** (**kubectl decribr netcoreapi**) and get the end         point IP
    ```
    "Endpoints": "10.1.0.159"
    "API": "http://10.1.0.159:80/Home        
    ```
    
    Alternatively, Instead of directly using application level config file. We can make use of kubenetes config maps. Here is how.
    ```
    apiVersion: v1
    kind: ConfigMap
    metadata:
     name: appsettings
    data:
     appsettings.json: |-
      {
      "api":"http://10.1.0.159:80/Home"
      }
    ```
    
    Apply the config map.
    ```
    kubectl apply -f .\ConfigMapUI.yml
    ```
    Lets modify the UI deployment yml
    
    Here is part of deployment yml file 
    ```
   ........
   .......
     ports:
        - containerPort: 80
        volumeMounts:
          - name: netcoreui-volume
            mountPath: /app/Settings
      volumes:
        - name: netcoreui-volume
          configMap: 
            name: appsettings
    ```
    
    Apply Deployment yml
    ```
    kubectl apply -f .\kubernetesDeployment.yml
    ```
    Now you can check inside the pod where you can see the deployed config map file 
    
    ![image](https://user-images.githubusercontent.com/49226342/167467011-041d085e-f94f-412b-8e1f-d82f841f3397.png)

