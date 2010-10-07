Entity Framework is only being used as a domain model designer and POCO code 
generation utility. Queries against the EFModelContext (ObjectContext) will not 
work as expected. All data access must be performed via the abstraction with Atlantis 
triplets or a Mock data provider. 