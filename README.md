# MemeBot
This is a meme bot for Discord that I made back in 2018. While it is not in use anymore, I feel this is a good sample of my work. I cache the memes into RAM from [a folder in a GitHub repository](https://github.com/kylecourounis/Patch/tree/master/Memes), and then when the command is triggered in Discord, a random one is chosen. 

## Why is this an ASP.NET Core app?
Something you may notice is that this is not a console app, but actually an ASP.NET Core app. This is because I found a way to use [Heroku's](heroku.com) free dynos to host any C# application. (Heroku is a hosting platform)

While they do not allow you to run a C# console app, they will let you host an ASP.NET Core app. I figured if I put the C# code into an ASP.NET Core project and then just run it as a web app, I could run the bot without my PC being on all the time. Sure enough, it worked.

## License
This project is licensed under the MIT License. 
