# Rest API .NET core Web API task

## How to run

### Visual Studio 
1. clone repo
2. click on api2.sln
3. You can use cURL in a terminal to get the reponse with the following parameters:
   
        curl -X 'GET' 'http://localhost:5114/api/rates?loanType=owner-occupied&term=30' -H 'accept: */*'

### Command  line
1. clone repo
2. navigate to folder containing api2.sln
3. Run

        cd RateApi
        dotnet restore # Download NuGet packages
        dotnet run     # Build and run project

4. You can use cURL in a terminal to get the reponse with the following parameters
   
        curl -X 'GET' 'http://localhost:5114/api/rates?loanType=owner-occupied&term=30' -H 'accept: */*'

### VS Code
1. Clone repo
2. Open folder in VS Code
3. In the integrated terminal: 

        cd RateApi
        dotnet run

4. You can use cURL to get the reponse with the following parameters:

        curl -X 'GET' 'http://localhost:5114/api/rates?loanType=owner-occupied&term=30' -H 'accept: */*'
