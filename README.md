>> Spiffy v0.6.1

Spiffy is a gmail notifier written in C#.
Created in the period 2009-2013, not maintained since then.
Software used; Visual Studio Express 2010/2013/2022.

Spiffy was packed with an NSIS installer and uploaded to a (now offline) website for download, an optional .exe only was also available.
The installer portion is not uploaded to github, if you build Spiffy just run the exe from anywhere (it will switch to USB mode).

>> Main features;

- Supports free Gmail and Google Apps mail (broken since 2013)
- Check up to 5 accounts, Inbox or custom Label
- Customize interface, notifier, sound alerts and more!
- Tell Me Again feature for missed alerts
- Proxy support for corporate networks
- Autostart & Hide functions
- Runs from USB and network drives
- Translated in 7 languages;
- Chinese (Traditional), Dutch, French, Hebrew, Polish, Portuguese, Russian

>> Some of the reviews of Spiffy are still online;

- SnapFiles - http://www.snapfiles.com/get/spiffy.html
- MajorGeeks - https://www.majorgeeks.com/files/details/spiffy.html
- Softpedia - https://www.softpedia.com/get/Internet/E-mail/Mail-Utilities/Spiffy.shtml
- BetaNews - http://fileforum.betanews.com/detail/Spiffy/1256838902/1

>> Content from the help section of the old website;

# Create custom Date & Time formats
You can modify the date and time format in the alert and log window. Here are some examples and how to create them.

MMM d, h:mm == Nov 4, 9:23
ddd, d MMM @ HH:mm:ss == Wed, 4 Nov @ 21:23:01
M\/d, h:mm tt == 11/4, 9:23 AM

# Where is the configuration saved?
Settings are saved in your Windows profile (ApplicationData\Spiffy or AppData\Roaming\Spiffy) if you run it from the "Program Files (x86)\Spiffy" folder. If you run Spiffy outside your "Program Files" folder it will switch to USB Mode and save your settings in the same location as the executable.

# Save configuration to a custom location
If you want to save your configuration anywhere else use this feature.
For example you want to save in F:\somefolder start Spiffy like this;

"C:\spiffy\spiffy.exe F:\somefolder"

# How to check the All Mail, Starred and Spam folders
To check the All Mail, Starred or Spam folders use these labels in Spiffy;
all
starred
spam

>> Code and Icons used in Spiffy;

Gmail Atom Tools - Ryan S. Cook
http://ryanscook.com/adminsBlog/2005/05/c-net-gmail-tools_26.html

Silk Icon Set - Mark James
http://www.famfamfam.com/lab/icons/silk/

TaskbarNotifier - John O'Byrne
http://www.codeproject.com/KB/miscctrl/taskbarnotifier.aspx

Portable Settings - CodeMonkey
http://www.codeproject.com/KB/vb/CustomSettingsProvider.aspx

--EOF
