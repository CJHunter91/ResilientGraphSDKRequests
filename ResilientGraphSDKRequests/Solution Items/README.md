
# README

## Dependencies

- Microsoft.Identity.Client
- Microsoft.Graph.Auth (preview)

## How to build the app

- Start with a new project

## Running the project locally

# Setting up an app registration

- Create an app registration for the is project
- Give the app registration an application permission to access Microsoft Graph
    - For this demo User.Read.All is sufficient
- Create a client secret and copy into your clipboard

# Run the project
- Update 'appsettings.json' to contain the values below
- Copy the template from the appsettings.json and insert the necessary values (They can be found in your azure env)
	- "GraphClientId": This should be the same as the client id above
    - "GraphClientSecret": This can be generated in the RegisterManagementAPI B2C app under "Certificates & Secrets"
    - "TenantID": This is the B2C tenant id
- Select the 'ResilientGraphSDKRequests' project to run
- Run the project
- Navigate to "https://localhost:5000/users" to view the swagger file

This should present a list of user IDs copy one and navigate to https://localhost:5000/users/$userId  where $userId is the id you copied. 
This will return the user name. 

To test the resilient requests are working navigate to https://localhost:5000/users/1.

You will see in the debug console that the request responded with 404 NotFound and then tries again.