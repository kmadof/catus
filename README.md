# catus

--------------

## Tracked object

C# had a single capture for all the lambdas in a method, both are held by persistent. Nasty bug you get in prod systems. Decompiled code with compiled-generated code look like below:

```csharp
private static void InnerScope()
{
      Program.\u003C\u003Ec__DisplayClass3_0 cDisplayClass30 = new Program.\u003C\u003Ec__DisplayClass3_0();
      cDisplayClass30.obj1 = new TrackedObject("Obj1");
      cDisplayClass30.obj2 = new TrackedObject("Obj2");
      // ISSUE: method pointer
      Program.Ephemeral(new Action((object) cDisplayClass30, __methodptr(\u003CInnerScope\u003Eb__0)));
      // ISSUE: method pointer
      Program.Persistent(new Action((object) cDisplayClass30, __methodptr(\u003CInnerScope\u003Eb__1)));
}

[CompilerGenerated]
private sealed class \u003C\u003Ec__DisplayClass3_0
{
      public TrackedObject obj1;
      public TrackedObject obj2;

      public \u003C\u003Ec__DisplayClass3_0()
      {
        base.\u002Ector();
      }

      internal void \u003CInnerScope\u003Eb__0()
      {
        Console.WriteLine("{0} {1}", (object) this.obj1.Name, (object) this.obj2.Name);
      }

      internal void \u003CInnerScope\u003Eb__1()
      {
        Console.WriteLine(this.obj2.Name);
      }
}

```