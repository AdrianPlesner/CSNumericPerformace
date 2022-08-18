#!/bin/bash

comp=$(which javac) 

if [ "$comp" == "" ]; then
    echo "javac not found! Please install javac to continue" && exit
fi 

cd "$1" || exit

echo -n "Compiling... "
SUBSTRING=$(echo "$2"| cut -d'"' -f 2)
if test "$SUBSTRING" != "" ; then
  echo -n "Compiler options: $SUBSTRING... "
  javac *.java "$SUBSTRING"
else
  echo -n "No additional compiler options found... "
  javac *.java
fi

jar -cmf MANIFEST.MF JavaBench.jar *.class 
printf "#!/bin/bash\njava -jar \"%s/JavaBench.jar\" \$1" "$1" > JavaBench.sh
sudo chmod +x JavaBench.sh
echo "Done!"
exit 
