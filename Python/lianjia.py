# author:钟辉

# -*- coding: utf-8 -*-
import os
import random
import re
from urllib import request

import scrapy
from scrapy import cmdline, Request

from StudyProject.items import CityItem, CommunityItem


# proxy_pool=[{'http':'222.189.191.50:9999'}]
class LianjiaSpider(scrapy.Spider):
    name = 'lianjia'
    allowed_domains = ['lianjia.com']
    num = 1

    def start_requests(self):
        cities = ['zz']
        for city in cities:
            url = 'https://{}.lianjia.com/xiaoqu/pg1'.format(city)
            yield Request(url, callback=self.parse)

    def parse(self, response):
        # size匹配的内容很关键，决定输出的item的形式
        size = response.css('.content .listContent li')

        for a in size:
            ele = CityItem()
            #爬取信息
            ele['name'] = a.css('.info .title a::text').extract()
            ele['area_name'] = a.css('.info .positionInfo a::text').extract_first()
            ele['price'] = a.css('.xiaoquListItemRight .totalPrice span::text').extract()
            ele['info'] = a.css('.info .tagList span::text').extract()
            ele['build_time'] = a.css('.info .positionInfo::text').re('\d\d\d\d年建成')
            yield ele

        # 垂直爬取
        url_1 = size.css('.info .title a::attr(href)').extract()
        for url in url_1:
            url = url[:23] + "chengjiao/c" + url[30:]
            yield scrapy.Request(url, callback=self.parse_item, dont_filter=True)

        # 水平爬取
        page = response.xpath("//div[@class='page-box house-lst-page-box'][@page-data]").re("\d+")
        p = re.compile(r'[^\d]+')
        if len(page) > 1 and page[0] != page[1]:
            next_page = p.match(response.url).group() + str(int(page[1]) + 1)
            next_page = response.urljoin(next_page)
            yield scrapy.Request(next_page, callback=self.parse)
        # self.num += 1
        # p = re.compile(r'[^\d]+')
        # if self.num < 100:
        #     next_page = p.match(response.url).group() + str(self.num)
        #     next_page = response.urljoin(next_page)
        #     yield scrapy.Request(next_page, self.parse)
        # if self.num == 100:
        #     self.num = 1;

    def parse_item(self, response):
        filtrate = response.css('.info')
        for each in filtrate:
            item = CommunityItem()
            item['name'] = each.css('.title a::text').re('(.*?)\s\d室')
            item['total_price'] = each.css('.address .totalPrice span::text').extract()
            item['price'] = each.css('.flood .unitPrice span::text').re('(\d+)')
            item['type1'] = each.css('.title a::text').re('(\d)室')
            item['type2'] = each.css('.title a::text').re('(\d)厅')
            item['square'] = each.css('.title a::text').re('厅\s(\d.*?)平')
            item['date'] = each.css('.address .dealDate::text').extract()
            info = each.css('.address .houseInfo::text').extract_first()
            info = info.replace(u'\xa0', u'')  # 去掉空白符
            item['info'] = info
            yield item

        #爬取下一页
        page = response.xpath("//div[@class='page-box house-lst-page-box'][@page-data]").re("\d+")
        if len(page):
            p = re.compile(r'[^\d]+')
            pageNext = response.css('.content .contentBottom div::attr(page-url)').re('c\d+')
            if page[1] != page[2]:
                next_page = 'https://zz.lianjia.com/chengjiao/pg' + str(int(page[2]) + 1) + pageNext[0]
                yield scrapy.Request(next_page, callback=self.parse_item)


if __name__ == '__main__':
    args = "scrapy crawl lianjia".split()
    cmdline.execute(args)
