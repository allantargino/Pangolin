# -*- coding: utf-8 -*-
"""
Created on Wed Mar 15 15:59:39 2017

@author: alcalleb
"""

# -*- coding: utf-8 -*-
"""
Created on Thu Feb  9 14:52:06 2017

@author: alcalleb
"""

import scrapy
import pandas as pd
import codecs

list_subjects=["international","sport"]

#for thematic in list_subjects:
#    dialogs=pd.read_json(thematic+" a.json" )
#    dialogues=dialogs[dialogs]['texte']

class BlogSpider(scrapy.Spider):
    name = 'blogspider'
#    start_url=["lemonde.fr/"+thematic+"/article/*" for thematic in list_subjects]
    start_urls=["http://www.lemonde.fr/donald-trump/article/2017/03/14/la-journee-de-donald-trump-52-millions-23-etats-et-l-inspecteur-gadget_5093934_4853715.html"]
    
    def parse(self, response):
        for title in response.css("div.contenu_article"):
#            for test in title.css('div.article'):
            print("CACAAAAAAAAAAAAAAAAAAAAAA")
            y={'texte':[s for s in title.css("p").extract()],}
            y['texte'].append([s for s in title.css("h2.taille_courante")])
#                y['texte']=[s for s in title.xpath('p/text()').extract()]
            yield(y)

#            for sentence in title.css('p'):
#                yield{'count':sentence.xpath('p/text()').extract_first()}
#                pass
#                yield{'count':"1"}
#       

#         next_page = response.css('div.prev-post > a ::attr(href)').extract_first()
#        if next_page:
#            yield scrapy.Request(response.urljoin(next_page), callback=self.parse)

#urls=pd.read_json("URLs.json")
#print(urls["title"][0].replace(" ","").replace("\n",""))
