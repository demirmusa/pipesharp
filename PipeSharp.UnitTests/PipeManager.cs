using System;

namespace PipeSharp
{
    public static class PipeManager
    {
        public static T Tap<T>(this T arg0, Action<T> action)
        {
            action.Invoke(arg0);
            return arg0;
        }
        //Pipe functions goes here
        public static TO1 Pipe<T, TO1>(this T arg0, Func<T, TO1> func1)
        {
            return func1.Invoke(arg0);
        }
        public static TO2 Pipe<T, TO1, TO2>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2)
        {
            return func2.Invoke(func1.Invoke(arg0));
        }
        public static TO3 Pipe<T, TO1, TO2, TO3>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3)
        {
            return func3.Invoke(func2.Invoke(func1.Invoke(arg0)));
        }
        public static TO4 Pipe<T, TO1, TO2, TO3, TO4>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4)
        {
            return func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0))));
        }
        public static TO5 Pipe<T, TO1, TO2, TO3, TO4, TO5>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5)
        {
            return func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0)))));
        }
        public static TO6 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6)
        {
            return func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0))))));
        }
        public static TO7 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7)
        {
            return func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0)))))));
        }
        public static TO8 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8)
        {
            return func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0))))))));
        }
        public static TO9 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8, TO9>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8, Func<TO8, TO9> func9)
        {
            return func9.Invoke(func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0)))))))));
        }
        public static TO10 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8, TO9, TO10>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8, Func<TO8, TO9> func9, Func<TO9, TO10> func10)
        {
            return func10.Invoke(func9.Invoke(func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0))))))))));
        }
        public static TO11 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8, TO9, TO10, TO11>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8, Func<TO8, TO9> func9, Func<TO9, TO10> func10, Func<TO10, TO11> func11)
        {
            return func11.Invoke(func10.Invoke(func9.Invoke(func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0)))))))))));
        }
        public static TO12 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8, TO9, TO10, TO11, TO12>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8, Func<TO8, TO9> func9, Func<TO9, TO10> func10, Func<TO10, TO11> func11, Func<TO11, TO12> func12)
        {
            return func12.Invoke(func11.Invoke(func10.Invoke(func9.Invoke(func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0))))))))))));
        }
        public static TO13 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8, TO9, TO10, TO11, TO12, TO13>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8, Func<TO8, TO9> func9, Func<TO9, TO10> func10, Func<TO10, TO11> func11, Func<TO11, TO12> func12, Func<TO12, TO13> func13)
        {
            return func13.Invoke(func12.Invoke(func11.Invoke(func10.Invoke(func9.Invoke(func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0)))))))))))));
        }
        public static TO14 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8, TO9, TO10, TO11, TO12, TO13, TO14>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8, Func<TO8, TO9> func9, Func<TO9, TO10> func10, Func<TO10, TO11> func11, Func<TO11, TO12> func12, Func<TO12, TO13> func13, Func<TO13, TO14> func14)
        {
            return func14.Invoke(func13.Invoke(func12.Invoke(func11.Invoke(func10.Invoke(func9.Invoke(func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0))))))))))))));
        }
        public static TO15 Pipe<T, TO1, TO2, TO3, TO4, TO5, TO6, TO7, TO8, TO9, TO10, TO11, TO12, TO13, TO14, TO15>(this T arg0, Func<T, TO1> func1, Func<TO1, TO2> func2, Func<TO2, TO3> func3, Func<TO3, TO4> func4, Func<TO4, TO5> func5, Func<TO5, TO6> func6, Func<TO6, TO7> func7, Func<TO7, TO8> func8, Func<TO8, TO9> func9, Func<TO9, TO10> func10, Func<TO10, TO11> func11, Func<TO11, TO12> func12, Func<TO12, TO13> func13, Func<TO13, TO14> func14, Func<TO14, TO15> func15)
        {
            return func15.Invoke(func14.Invoke(func13.Invoke(func12.Invoke(func11.Invoke(func10.Invoke(func9.Invoke(func8.Invoke(func7.Invoke(func6.Invoke(func5.Invoke(func4.Invoke(func3.Invoke(func2.Invoke(func1.Invoke(arg0)))))))))))))));
        }
    }
}
