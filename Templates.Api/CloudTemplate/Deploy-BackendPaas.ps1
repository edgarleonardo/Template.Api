### Define Deployment Variables
{
$resourceGroupLocation = 'West US'
$resourceGroupName = 'backendSystem-paas'
$resourceDeploymentName = 'backendSystem-paas-deployment'
$templatePath =  '[Root_Url]\' + 'CloudTemplate'
$templateFile = 'ARM_Application_Template.json'
$template = $templatePath + '\' + $templateFile
}

### Create Resource Group
{
New-AzureRmResourceGroup `
    -Name $resourceGroupName `
    -Location $resourceGroupLocation `
    -Verbose -Force
}

### Deploy Resources
{
New-AzureRmResourceGroupDeployment `
    -Name $resourceDeploymentName `
    -ResourceGroupName $resourceGroupName `
    -TemplateFile $template `
    -Verbose -Force
}