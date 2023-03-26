#!/bin/bash
set -e
>&2 echo "SQL Server is up - executing command"

/root/.dotnet/tools/dotnet-ef database update --connection "Host=postgres; Password= $POSTGRES_PASSWORD; Username=$POSTGRES_USER; Database=$POSTGRES_DB"

