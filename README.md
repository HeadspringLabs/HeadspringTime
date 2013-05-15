# HeadspringTime

A lightweight implementation of SystemClock that will help make your applications more testable when dealing with dates and times.

## General Usage

You can use `SystemClock` just like you would with `System.DateTime`:

```csharp
var now = SystemClock.UtcNow; // instead of DateTime.UtcNow
```
    
So far, no visual benefit, **but** if you have code that assigns the current time, you can temporarily override this value by using the Stub method (which is `IDisposable` and can take advantage of the C# `using` keyword.

```csharp
using (SystemClock.Stub(new DateTime(2001, 5, 5))
{
    var now = SystemClock.UtcNow; // will be May 5th, 2001
}
```

This is very helpful when testing business logic that relies on dates and times.

### Notes

You may notice that `SystemClock` uses `UtcNow` instead of `Now`. This is because using UTC dates and times throughout an application makes it much easier to deal with time zones and local time.

For more information on how to convert to a different time zone: [TimeZoneInfo.ConvertTimeFromUtc](http://msdn.microsoft.com/en-us/library/system.timezoneinfo.converttimefromutc.aspx) or to local time using [DateTime.ToLocalTime](http://msdn.microsoft.com/en-us/library/system.datetime.tolocaltime.aspx)
