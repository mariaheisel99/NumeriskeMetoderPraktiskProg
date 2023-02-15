default : Out1.txt Out2.txt

# Exe 1
Out1.txt : main1.exe 
	mono $< > $@
main1.exe : main1.cs  
	 mcs -target:exe -out:$@ $<

                
#Exe 2
Out2.txt : main2.exe
	mono $< > $@ 

main2.exe : main2.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -f main1.exe main2.exe
