//usr/bin/env fsharpi $0 $@;exit
// http://qiita.com/Nabetani/items/1c83005a854d2c6cbb69
// http://nabetani.sakura.ne.jp/hena/ord24eliseq/

open System
open System.Runtime.InteropServices

[<Literal>]
let libc_="c"
module libc=
 [<DllImport(libc_,CallingConvention=CallingConvention.Cdecl,EntryPoint="cbrt")>]
 extern double cbrt(double n)

let is_sq (n:int) =
  let x=int(Math.Sqrt(double(n)))
  x*x=n
let is_cb (n:int) =
  let x=int(libc.cbrt(double(n)))
  x*x*x=n
let is_multiple (i:int) (n:int) = i%n=0
let is_le (i:int) (n:int) = i<=n

let generate =
  seq{
    let mutable i=1
    while true do
      yield i
      i<-i+1
  }
let drop_prev check (_prev:int seq) =
  seq{
    let prev=_prev.GetEnumerator()
    prev.MoveNext()
    let mutable a=prev.Current
    prev.MoveNext()
    let mutable b=prev.Current
    while true do
      if not (check b) then
        yield a
      a<-b
      prev.MoveNext()
      b<-prev.Current
  }
let drop_next check (_prev:int seq) =
  seq{
    let prev=_prev.GetEnumerator()
    prev.MoveNext()
    let mutable a=prev.Current
    prev.MoveNext()
    let mutable b=prev.Current
    yield a
    while true do
      if not (check a) then
        yield b
      a<-b
      prev.MoveNext()
      b<-prev.Current
  }
let drop_n check (n:int) (_prev:int seq) =
  seq{
    let prev=_prev.GetEnumerator()
    let mutable i=0
    while true do
      i<-i+1
      prev.MoveNext()
      let a=prev.Current
      if not (check i n) then
        yield a
  }

let f0=[
  ('S',fun e->drop_next is_sq e);
  ('s',fun e->drop_prev is_sq e);
  ('C',fun e->drop_next is_cb e);
  ('c',fun e->drop_prev is_cb e);
  ('h',fun e->drop_n is_le 100 e);
]
let f=Seq.append f0 (List.map (fun i->(char(int('0')+i),fun e->drop_n is_multiple i e)) [2..9]) |> dict

let solve line=List.ofSeq line |> Seq.fold (fun s e->f.[e] s) generate |> Seq.take 10 |> Seq.map string |> String.concat "," |> Console.WriteLine

let mutable line=Console.ReadLine() in
  while line<>null do
    solve line
    Console.Out.Flush()
    line<-Console.ReadLine()
