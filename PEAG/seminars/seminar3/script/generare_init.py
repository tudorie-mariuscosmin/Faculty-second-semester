import numpy as np

#preia date float dintr-un fisier text in care fiecare valoare este scrisa pe o linie
def citeste(fis):
    with open(fis,'r') as f:
        c = [float(line.strip()) for line in f if line]
    # sau, mai simplu
    # c = np.genfromtxt(fis)
    return c

#verifica fezabilitatea alegerii x si calculeaza si f. obiectiv
def ok(x,n,c,v,max):
    val=0
    cost=0
    for i in range(n):
        val=val+x[i]*v[i]
        cost=cost+x[i]*c[i]
    return cost<=max,val


#genereaza populatia initiala
#I:
# fc, fv - numele fisierelor cost, valoare
# max - capacitatea maxima
# dim - numarul de indivizi din populatie
#E: pop - populatia initiala
def gen(fc,fv,max,dim):
    #citeste datele din fisierele cost si valoare
    c=citeste(fc)
    v=citeste(fv)
    #n=dimensiunea problemei
    n=len(c)
    #lucreaza cu populatia ca lista de dim elemente - liste cu cate n+1 indivizi
    pop=[]
    for i in range(dim):
        gata=False
        while gata == False:
            #genereaza candidatul x cu elemente pe [0,1]
            x=np.random.uniform(0,1,n)
            gata,val=ok(x,n,c,v,max)
        #am gasit o solutie candidat fezabila, in data de tip ndarray (vector) x
        # x este transformat in lista
        x=list(x)
        # adauga valoarea
        x=x+[val]
        #adauga la populatie noul individ cu valoarea f. obiectiv - adauga inca o lista cu n+1 elemente ca element al listei pop
        pop=pop+[x]
    return pop

#Apel
#import generare_init as gi
#p=gi.gen("cost.txt","valoare.txt",30,5)

