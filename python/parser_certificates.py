# -*- coding: utf-8 -*-
# Agradeço a Deus pelo dom do conhecimento

import os
import sys
import json

try:
	path = sys.argv[1] #"/home/papejajr/personal_archives/certificates"
except Exception as e:
	print('Favor informe o caminho dos certificações')
	exit(0)

directory = os.listdir(path)

folders = []
for folder in directory:
	currentPath = os.path.join(path, folder)
	folders.append(os.listdir(currentPath))

certificates = list()
for files in folders:
	for file in files:
		certificates.append(file.split(' - '))

# Filter valid certificates
certificates = list(filter(lambda x: len(x) == 4, certificates))

output = list()
for item in certificates:

	year =  item[1]
	workload =  item[3].partition('.')[0]
	description =  item[2]
	institute =  item[0]

	output.append({
		"year": year,
		"workload": workload,
		"description": description,
		"institute": institute,
		"link": None,
	})

# List sorted in descending order
output = sorted(output, key=lambda t: t['year'], reverse=True)

path = 'certificates.json'
try:
	path =  os.path.join(sys.argv[2], path)
except Exception as e:
	print('File saved to default path')


with open(path, 'w', encoding='utf-8') as json_file:
	json.dump(output, json_file, ensure_ascii=False)
