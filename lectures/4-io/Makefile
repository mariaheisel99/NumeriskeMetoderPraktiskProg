#RM = rm --force
Out.txt : main.exe
	mono main.exe hello world -numbers:1,2,3,4,5,6,1> $@

main.exe : main.cs input.dll 
	mcs -target:exe -out:$@ \
	 $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

input.dll : input.cs
	mcs -target:library -out:$@ $(filter %.cs,$^)
.PHONEY: clean
clean:
	$(RM) *.exe *.dll [Oo]ut*

test: 
	echo $(RM)
