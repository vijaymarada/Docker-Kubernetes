
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
    
