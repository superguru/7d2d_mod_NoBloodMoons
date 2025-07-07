@echo off

set PROJECT=NoBloodMoons
set CHANGELOG_FILE=%PROJECT%\CHANGELOG.md
set MODINFO_FILE=%PROJECT%\ModInfo.xml

if not exist %CHANGELOG_FILE% (
set input=
) else (
set input=-i
)

git-changelog %input% -o %CHANGELOG_FILE%

@rem git-changelog --bump 2.0.0 -io NoBloodMoons\CHANGELOG.md 
