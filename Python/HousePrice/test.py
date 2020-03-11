# -*- coding: utf-8 -*-
import os
import re
from urllib import request

import scrapy

from scrapy import cmdline

from StudyProject.items import CityAreaItem


class TestSpider(scrapy.Spider):
    name = 'test'
    allowed_domains = ['lianjia.com']
    start_urls = ['https://wh.lianjia.com/xiaoqu/']

    def parse(self, response):
        size = response.css('.m-filter .position div a')
        for a in size:
            item = CityAreaItem()
            item['area'] = a.css('a::text').extract()
            yield item


if __name__ == '__main__':
    args = "scrapy crawl test".split()
    cmdline.execute(args)
