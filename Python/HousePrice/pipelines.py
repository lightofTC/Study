# author:钟辉
# -*- coding: utf-8 -*-

# Define your item pipelines here
#
# Don't forget to add your pipeline to the ITEM_PIPELINES setting
# See: https://doc.scrapy.org/en/latest/topics/item-pipeline.html
import copy

from scrapy import log
from twisted.enterprise import adbapi
from StudyProject.items import CityItem, CommunityItem, CityAreaItem


class StudyprojectPipeline(object):
    def __init__(self):
        dbparms = dict(
            host='localhost',
            port=3306,
            user='root',
            passwd='123456',
            db='test',
            use_unicode=True,
        )
        self.post = adbapi.ConnectionPool('pymysql', **dbparms)

    #判断爬取内容，分别存入不同的数据库表中
    def process_item(self, item, spider):
        if isinstance(item, CommunityItem):
            houseitem = copy.deepcopy(item)
            self.post.runInteraction(self._conditional_insert, houseitem)

        elif isinstance(item, CityItem):
            houseitem = copy.deepcopy(item)
            self.post.runInteraction(self._city_insert, houseitem)

        elif isinstance(item, CityAreaItem):
            houseitem = copy.deepcopy(item)
            self.post.runInteraction(self._cityArea_insert, houseitem)

        return item

    def _conditional_insert(self, tb, item):
        sql = """INSERT INTO zhengzhou_community(square, total_price, date, type1, price,
                name,info,type2)VALUES (%s,%s,%s,%s,%s,%s,%s,%s)"""
        #对数据进行初步筛选
        if item['price'] == ['暂无']:
            parms = (
                item['square'], item['total_price'], item['date'], item['type1'], 'null', item['name'],
                item['info'], item['type2'])
        else:
            parms = (
                item['square'], item['total_price'], item['date'], item['type1'], item['price'], item['name'],
                item['info'], item['type2'])
        tb.execute(sql, parms)

    def _city_insert(self, tb, item):
        sql = """INSERT INTO zhengzhou_city(info,name,area_name,price,build_time) VALUES (%s,%s,%s,%s,%s)"""
        if item['info'] == []:
            if item['build_time'] == []:
                parms = ('null', item['name'], item['area_name'], item['price'], 'null')
            else:
                parms = ('null', item['name'], item['area_name'], item['price'], item['build_time'])
        elif item['price'] == ['暂无']:
            parms = (item['info'], item['name'], item['area_name'], 'null', item['build_time'])
        elif item['build_time'] == []:
            parms = (item['info'], item['name'], item['area_name'], item['price'], 'null')
        else:
            parms = (item['info'], item['name'], item['area_name'], item['price'], item['build_time'])
        tb.execute(sql, parms)

    def _cityArea_insert(self, tb, item):
        sql = "INSERT INTO city_area(city, area) values (%s,%s)"
        parms = (item['city'], item['area'])
        tb.execute(sql, parms)


def handle_error(self, e):
    log.error(e)
