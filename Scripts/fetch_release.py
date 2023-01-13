import requests
from zipfile import ZipFile


file_name = "PAIA.zip"
url = "https://github.com/mesohandsome/FunAIKartTest/releases/latest/download/" + file_name


## Download the latest release from github repository
r = requests.get(url, stream = True)
with open(file_name, 'wb') as fd:
    for chunk in r.iter_content(chunk_size = 64):
        fd.write(chunk)
        
print('---Downloaded the release file---')


## Extract the downloaded file to current folder
ext_path = "./"
with ZipFile(file_name, 'r') as z:
    z.extractall(path = ext_path)
 
print('---Updated the release executable file---')