var MyPlugin = {
     IsOnMobilePlatform: function()
     {
         return UnityLoader.SystemInfo.mobile;
     }
 };
 
 mergeInto(LibraryManager.library, MyPlugin);