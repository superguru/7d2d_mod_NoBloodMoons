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

@rem Do NOT do this. Use git tag instead: rem git-changelog --bump 2.0.0 -io %CHANGELOG_FILE%

rem Steps to release a new version:
rem - Make sure everything is pushed to origin
rem - Update VERSION with the new version number
rem - Run zz_release.py %PROJECT% %MODINFO_FILE%
rem   - Check that VERSION exists, and read the new version from there
rem   - Check that the Project and the ModInfo paths match. This is seems redundant, but is a sanity check.
rem   - Read ModInfo.xml version, and quit if it is >= VERSION  !!! Need to output a NOP cmd file in this case
rem   - Update AssemblyInfo.cs with the new version
rem   - 
rem   - 
rem   - 
rem   - 
rem - git add .
rem - git commit -m "Release tag x.y.z"
rem - git tag -a x.y.z -m "Release tag x.y.z"
rem - git push origin
rem - git-changelog -i -o %CHANGELOG_FILE%
rem - git add .
rem - git commit -m "Release CHANGELOG for x.y.z"
rem - git push origin
rem 