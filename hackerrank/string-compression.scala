//usr/bin/env scala $0 $@;exit
object Solution{
	def main(args: Array[String]){
		val s=readLine()
		val a=Array[Char](1)
		val n=Array[Int](1)
		a(0)=s(0)
		for(i<-1 until s.length){
			if((a(0)!=s(i))){
				print(a(0))
				a(0)=s(i)
				if(n(0)>1)print(n(0))
				n(0)=0
			}
			n(0)+=1
		}
		print(a(0))
		if(n(0)>1)print(n(0))
	}
}