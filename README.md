```bash
# Setup reproduction database
sqlcmd -f 65001 < setup.sql # Or just run it in SSMS

# (Re)generate scaffold
dotnet linq2db scaffold -i MinimalReproduction04ECD0D4E3.json

# Compare against manually corrected scaffold
diff -u MinimalReproduction04ECD0D4E3.generated.cs MinimalReproduction04ECD0D4E3_corrected.cs # or vice versa
```