# Security policy

## Supported use

This is an educational reference project, not a supported production service. There are no
supported release branches or security-update guarantees.

## Safe operation

- Do not expose the API to the internet: authentication and authorization are not implemented.
- Do not commit connection strings, passwords, tokens, database backups, or real customer data.
- Override `ConnectionStrings__MyConnection` through local user secrets, environment
  variables, or a deployment secret store.
- Review NuGet audit output and update dependencies before using any code in another system.
- Treat all SQL scripts as development-only and review them before execution.

If you discover a vulnerability, report it privately through GitHub's security-advisory
feature rather than opening a public issue with exploit details.
