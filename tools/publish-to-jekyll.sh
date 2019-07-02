cd ../src/UnityTipsMuseum/
dotnet publish -c release
cp  -R bin/Release/netstandard2.0/publish/UnityTipsMuseum/dist/  ../../../giacomelli.github.io-jekyll/src/apps/unitytips-museum
rm -rf bin/

cd ../../tools
cp -R jekyll-files/ ../../giacomelli.github.io-jekyll/src/apps/unitytips-museum

cd ../../giacomelli.github.io-jekyll/
git status
git add .
git commit -m"#unitytips Museum updated"
git push

