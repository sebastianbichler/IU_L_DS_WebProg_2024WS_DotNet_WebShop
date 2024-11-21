using Aspire.Hosting;
using Aspire;


// Creates the Distributed App Builder
IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

#region Database
#endregion

#region Backend
builder.AddProject<Projects.CoreWebAPI>("corewebapi");
#endregion

#region Frontend
builder.AddProject<Projects.BlazorWasmStandaloneApp>("blazorwasmstandaloneapp");
#endregion

builder.Build().Run();
