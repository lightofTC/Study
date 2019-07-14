# 钟辉
# -*- coding: utf-8 -*-
import os
import re
from urllib import request

import scrapy
import scrapy
from scrapy import cmdline


class CityareaSpider(scrapy.Spider):
    name = 'cityArea'
    allowed_domains = ['lianjia.com']
    start_urls = ['https://jn.lianjia.com/xiaoqu/pg51']

    # 'https://sh.lianjia.com/xiaoqu/','https://bj.lianjia.com/xiaoqu/','https://gz.lianjia.com/xiaoqu/','https://sz.lianjia.com/xiaoqu/'
    #          'https://hz.lianjia.com/xiaoqu/','https://cq.lianjia.com/xiaoqu/','https://cd.lianjia.com/xiaoqu/','https://nj.lianjia.com/xiaoqu/'
    def parse(self, response):
        size = response.css('.content .leftContent .listContent li')
        for a in size:
            name = a.css('.img img::attr(alt)').extract()
            html = a.css('.img img::attr(data-original)').extract()
            if html != ['']:
                for i in range(len(name)):
                    file_path = os.path.join(os.getcwd() + '/img/jinan/', name[i] + '.jpg')
                    request.urlretrieve(html[i], file_path)

        page = response.xpath("//div[@class='page-box house-lst-page-box'][@page-data]").re("\d+")
        p = re.compile(r'[^\d]+')
        if len(page) > 1 and page[0] != page[1]:
            next_page = p.match(response.url).group() + str(int(page[1]) + 1)
            print(next_page + "*********************")
            next_page = response.urljoin(next_page)
            yield scrapy.Request(next_page, callback=self.parse)


if __name__ == '__main__':
    args = "scrapy crawl cityArea".split()
    cmdline.execute(args)
