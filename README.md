# NLog-Example-CheatBase

- cheat base for emutarkov easy to inject, easy to edit...

NLog.dll.nlog (only for cheatfile)
```
    <?xml version="1.0" encoding="utf-8" ?>
    <nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    	<targets>
    		<target name="Cheat.Base" xsi:type="Cheat.Base" />
    	</targets>
    </nlog>
```
NLog.dll.nlog (for emutarkov) - just add this line below other `<target>` inside `<targets>` section
```
<target name="Cheat.Base" xsi:type="Cheat.Base" />
```

If you want to talk with me, you can find me at this discord server.
https://discord.gg/T66tGKa
