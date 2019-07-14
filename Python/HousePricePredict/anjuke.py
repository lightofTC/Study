# -*- coding: utf-8 -*-
import scrapy
from scrapy import cmdline

from StudyProject.items import AnjuCityItem


class AnjukeSpider(scrapy.Spider):
    name = 'anjuke'
    allowed_domains = ['www.anjuke.com']
    start_urls = ['https://www.anjuke.com/fangjia/wuhan/wuhan/']

    def parse(self, response):
        size = response.css('.main-content .avger .fjlist-box')
        for each in size:
            item = AnjuCityItem()
            date = each.css('ul li .nostyle b::text').extract()
            per = each.css('ul li .nostyle span::text').extract()
            item['date'] = date
            item['per'] = per
            yield item


if __name__ == '__main__':
    args = "scrapy crawl anjuke".split()
    cmdline.execute(args)
