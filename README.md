# ST10272691 Functions App

## Overview
This repository contains the Azure Functions App developed for the CLDV6212 module, showcasing the integration of various Azure services to enhance the application's scalability, cost-effectiveness, and cloud suitability.

## Features
- **HTTP Trigger Function**: Responds to HTTP requests with a welcome message.
- **Timer Trigger Function**: Inserts data into Azure Tables at scheduled intervals.
- **Queue Trigger Function**: Reads from Azure Queue Storage and processes messages.
- **Blob Trigger Function**: Uploads files to Azure Blob Storage when a blob is added.
- **File Upload to Azure Files**: Sends files to Azure Files for storage.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- An Azure account with an active subscription

### Installation
1. Clone the repository:
   
   git clone https://github.com/Notz05/ST10272691-Functions-App-POE-PART-2.git
  
2. Navigate to the project directory:
   
   cd ST10272691_Functions_App
   
3. Restore the dependencies:
   
   dotnet restore
   

### Configuration
- Update the connection strings in the `local.settings.json` file with your Azure Storage account credentials and other necessary configurations.

### Running the Functions Locally
To run the functions locally, use the following command:

func start


### Deploying to Azure
1. Login to Azure CLI:
   
   az login
   
2. Deploy the functions:
  
   func azure functionapp publish <ST10272691-Functions-App>
  
## Links
- [GitHub Repository]Part 1(https://github.com/Notz05/CLDV-SEMESTER-2-POE.git )
- [GitHub Repository]Part 2(https://github.com/Notz05/ST10272691-Functions-App-POE-PART-2.git)

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements
- [Azure Documentation](https://docs.microsoft.com/en-us/azure/)
- Mrzyglod, K. (2022). Azure for Developers 2nd Edition. In K. Mrzyglod, Azure for Developers (p. 944). Birmingham: Pakt Publishing Ltd.

