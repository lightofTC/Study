# author:钟辉
# -*- coding: utf-8 -*-

# Define here the models for your scraped items
#
# See documentation in:
# https://doc.scrapy.org/en/latest/topics/items.html

import scrapy


class CommunityItem(scrapy.Item):
    # define the fields for your item here like:
    name = scrapy.Field()
    type1 = scrapy.Field()
    type2 = scrapy.Field()
    total_price = scrapy.Field()
    price = scrapy.Field()
    date = scrapy.Field()
    square = scrapy.Field()
    info = scrapy.Field()


class CityItem(scrapy.Item):
    area_name = scrapy.Field()
    info = scrapy.Field()
    name = scrapy.Field()
    price = scrapy.Field()
    build_time = scrapy.Field()


class CityAreaItem(scrapy.Item):
    city = scrapy.Field()
    area = scrapy.Field()


class AnjuCityItem(scrapy.Item):
    date = scrapy.Field()
    per = scrapy.Field()
