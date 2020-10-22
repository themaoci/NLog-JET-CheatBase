# NLog-JET-CheatBase

- cheat base for justemutarkov easy to inject, easy to edit...

NLog.dll.nlog (only for JET)
```
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <targets>
        <target name="JET" xsi:type="JET" />
        <target name="Cheat.Base" xsi:type="Cheat.Base" />
    </targets>
</nlog>
```

If you want to talk with me, you can find me at this discord server.
https://discord.gg/T66tGKa

## Why Parallel.For() ??
  its used to speed up calculation and data assign. for example we have 4 Extraction Data to proceed and you have 4 avaliable threads so they will took time of calculation of 1 such data not 4 (yes its a broken idea but its working)
  
## Items are hard thing to proceed
   ...cause its alot of them mostly ~3000 ob objects. so we gonna use new thread to sync this data each 0.5 second (well we can increase that to 1 or 5 seconds but i think 0.5 sec. is good enough and shouldnt lag that much
   
## Locking to not allow to access data from diffrent threads
  im still not good at this... im still learning how to properly made this working well