# WebApi With Azure Resource Manager

In this example was developed an ASP.NET Core API with Entity Framework, Unit Testing and the whole infraestructure that will hold the entire application using Azure Resource Templates and PowerShell to run those templates and create the components on Azure.


# How to Test Api on Development

Clone the Git Repo and once done, go and head to the tools options on Visual Studio and look for the Package Console Manager, once there just run the command below:

> update-database

A message will be prompt and if not error occured then you coud just head to the following url:

> https://localhost:44328/swagger

## Templates Created To Application on Azure

The templates that will be published to Azure is located on the folder:
> ~/CloudTemplate/ARM_Application_Template.json

The Diagram is below:
![enter image description here](https://raw.githubusercontent.com/edgarleonardo/Template.Api/master/Templates.Api/CloudTemplate/diagram.jpg)

## Publish to Azure this Template

To publish the created template to Azure is needed to install AzureRm in your PowerShell screen.

Open up a PowerShell screen as administrator and run the command below:
>Install-Module -Name AzureRM

Once install run the next command to autenticate with your Azure Cloud Account, I assumed you already have an Azure account ready to use if not please check [this](https://azure.microsoft.com/en-us/free/).

> Connect-AzureRmAccount

This will prompt up a screen requiring the user and password and once done you will be authenticated and ready to deploy the template.

## Deploy the Template

To deploy the template there is a script that has all needed to make the deployment and is located on:

> ~/CloudTemplate/Deploy-BackendPaas.ps1

In the file, replace the text `[Root_Url]` for the root where the folder is located to allow the script be able to find the .json file where all configurations are.

Once the string is replaced, just run the Power Shell file and the magic will happen.
