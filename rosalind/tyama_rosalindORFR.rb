#!/usr/bin/ruby
codon={"UUU"=>"F","UUC"=>"F","UUA"=>"L","UUG"=>"L","UCU"=>"S","UCC"=>"S","UCA"=>"S","UCG"=>"S","UAU"=>"Y","UAC"=>"Y","UGU"=>"C","UGC"=>"C","UGG"=>"W","CUU"=>"L","CUC"=>"L","CUA"=>"L","CUG"=>"L","CCU"=>"P","CCC"=>"P","CCA"=>"P","CCG"=>"P","CAU"=>"H","CAC"=>"H","CAA"=>"Q","CAG"=>"Q","CGU"=>"R","CGC"=>"R","CGA"=>"R","CGG"=>"R","AUU"=>"I","AUC"=>"I","AUA"=>"I","AUG"=>"M","ACU"=>"T","ACC"=>"T","ACA"=>"T","ACG"=>"T","AAU"=>"N","AAC"=>"N","AAA"=>"K","AAG"=>"K","AGU"=>"S","AGC"=>"S","AGA"=>"R","AGG"=>"R","GUU"=>"V","GUC"=>"V","GUA"=>"V","GUG"=>"V","GCU"=>"A","GCC"=>"A","GCA"=>"A","GCG"=>"A","GAU"=>"D","GAC"=>"D","GAA"=>"E","GAG"=>"E","GGU"=>"G","GGC"=>"G","GGA"=>"G","GGG"=>"G"}
s=gets.chomp.tr('T','U')
a1=s.size.times.map{|i|
	t=''
	if s[i,3]=='AUG'
		s[i..-1].chars.each_slice(3){|e|codon[x=e*''] ? t<<codon[x] : break}
	end
	t
}
s=s.reverse.tr('AUGC','UACG')
a2=s.size.times.map{|i|
	t=''
	if s[i,3]=='AUG'
		s[i..-1].chars.each_slice(3){|e|codon[x=e*''] ? t<<codon[x] : break}
	end
	t
}
puts (a1+a2).max_by(&:size)