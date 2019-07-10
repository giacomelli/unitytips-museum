call ./test-on-jekyll.cmd

cd ../../giacomelli.github.io-jekyll/src/apps/unitytips-museum
git status
git add .
git commit -m"#unitytips Museum updated"
git push

cd ../../unitytips-museum