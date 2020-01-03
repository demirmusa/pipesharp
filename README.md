# Pipesharp

A code I wrote for entertainment purposes. Not recommended for use in real projects.

It generates [RxJS Pipe](https://rxjs-dev.firebaseapp.com/api/index/function/pipe) and [RxJS Tap](https://rxjs-dev.firebaseapp.com/api/operators/tap) operators for c#.

#### Generating PipeManager.cs

* Download project. 

* Run **PipeSharp.GeneratorConsole**. it will generate an extension class [PipeManager.cs](https://github.com/demirmusa/pipesharp/blob/master/PipeSharp.UnitTests/PipeManager.cs) which contains `Pipe` and `Tap` functions into the bin folder.  

  (You can change directory by parameter. Check [GeneratePipeManagerCs](https://github.com/demirmusa/pipesharp/blob/d50682ff5022be0aeadbc76bbcb5b3db6237176c/PipeSharp/PipeManagerGenerator.cs#L9) function)

* You can use generated class anywhere you want.

#### Usage

* Include **PipeManager.cs** to your project

* Then you will be able to use `Pipe` and `Tap` functions

  **Pipe:**  It calls functions with the result of the previous one. 

  ```csharp
  public static TO2 Pipe<T, TO1, TO2>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2)
  {
       return func2.Invoke(func1.Invoke(arg0));
  }
  ```

  **Tap:**  Invokes functions without breaking chain

  ```csharp
  public static T Tap<T>(this T arg0, Action<T> action)
   {
       action.Invoke(arg0);
       return arg0;
   }
  ```

  

  *Example*

  ```csharp
  private string MakeMeString(int number) => number.ToString();
  
  private int MakeMeInt(string number) => int.Parse(number);
  
  ...
  public void Test(){
       int intNumber = "5".Pipe(
                   MakeMeInt,
                   MakeMeString,
                   MakeMeInt                
               );    
  }
  ```

  

  ```csharp
  public interface ITest{
     Person CreateAndGetPerson(string name);
     User CreateAndGetUser(Person p);
     Account CreateAndGetAccount(User u);
     void ActivateAccount(Account a);
     BalanceInfo GetCurrentBalance(Account a);
     decimal BalanceAsDecimal(BalanceInfo b);    
  }
  
  public class MyClass{
      private ITest _test;
      
      public decimal DoStuff(){
       	return "Musa".Pipe(
                  CreateAndGetPerson,
                  CreateAndGetUser,
                  CreateAndGetAccount
              ).Tap(ActivateAccount)
              .Pipe(
                  GetCurrentBalance
                  BalanceAsDecimal
              );        
      }
  }
  
  ```

  

**Note:**  To generate pipe function which allow you to use more than 15 function at once, call generator with loop parameter.

*PipeSharp.GeneratorConsole*

```csharp
static void Main(string[] args)
{
    var pipeManagerGenerator = new PipeManagerGenerator();
    pipeManagerGenerator.GeneratePipeManagerCs(loop:25);
}
```