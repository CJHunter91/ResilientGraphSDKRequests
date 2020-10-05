
# README

## Dependencies

- Microsoft.Identity.Client
- Microsoft.Graph.Auth (preview)

## Running the project locally
- Create a new file in the RegisterManagementApi project called 'appsettings.Development.json'
- Copy the template from the appsettings.json and insert the necessary values (They can be found in the localsiccardev env)
	- "ClientId" Can be found under app registrations in the B2C tenant. The app is call RegisterManagementApi
    - "Domain" This is the domain of the B2C tenant
    - "SignUpSignInPolicyId" This B2C policy that you wish to use for sigining into the app.
	- "GraphClientId": This should be the same as the client id above
    - "GraphClientSecret": This can be generated in the RegisterManagementAPI B2C app under "Certificates & Secrets"
    - "TenantID": This is the B2C tenant id
    - "ExtensionId": This can be found in app registrations and is the client id of the b2c-extensions-app
	- "InstrumentationKey": The application insights key for the local environment
	- "ClientId": Same client id as above
    - "ClientSecret": Samve client secret as above
    - "ResourceUri": This is the resource uri of the Siccar app registration in the b2c tenant
    - "TenantID": This should be the same as the above tenantId
    - "BaseUrl": The base url of the Siccar application
	- "RegisterAPIObjectId": This is the service principal id of the registerApi application and can be found in 'enterprise applications'
    - "SNRInterServiceObjectId": This is the service principal id of the snr-inter-service-auth app and can be found in 'enterprise applications'
	- "APIKey": This is the api key for the sendgrid account,
    - "SendingAddress": Address that the email will be sent from,
    - "SendingName": The name that will be shown as the sender in a email client
     - "TemplateId": This is the the template id of the email that will be sent
- Select the RegisterManagementApi project to run
- Run the project
- Navigate to "https://localhost:6003" to view the swagger file