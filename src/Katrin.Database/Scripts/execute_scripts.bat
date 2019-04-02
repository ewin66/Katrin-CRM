@ECHO OFF
CLS

rem : prompt for parameters
:prompt_sqlinstance
SET /P _sqlinstance=Please enter SQL Server instance name:
IF "%_sqlinstance%"=="EXIT" GOTO:EOF
IF "%_sqlinstance%"=="" GOTO:sub_nosqlinstance
IF NOT EXIST %_sqlinstance% GOTO:sub_nofile

:prompt_sqllist
SET /P _serverfile=Please enter SQL List file name:
IF "%_sqllist%"=="EXIT" GOTO:EOF
IF "%_sqllist%"=="" GOTO:sub_nosqllist
IF NOT EXIST %_sqllist% GOTO:sub_nofile

rem : remove previous log files
mkdir .\output
DEL /Q .\output\*.log
CLS

FOR /F %%a IN (.\%_sqllist%) DO (
    ECHO Executing file %%a
    SQLCMD -E -S%_sqlinstance% -w8000 -W -s"|" -i%%a > .\output\%%a.log
)

rem : clear variables
SET _sqlinstance=
SET _sqllist=

ECHO ----------------------------------------------------
ECHO Process completed
GOTO:EOF

:sub_nosqlinstance
ECHO SQL file name not supplied
GOTO:EOF

:sub_nosqllist
ECHO Server List file name not supplied
GOTO:EOF

:sub_nofile
ECHO SQL file does not exist
GOTO :prompt_sqlfile
