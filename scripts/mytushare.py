# encoding: utf-8

from sqlalchemy import *
import tushare as ts
import time, os, sched

schedule = sched.scheduler(time.time, time.sleep)
engine = create_engine("mysql://root:Root12345@127.0.0.1/stock_data?charset=utf8")

def get_stock_basics():
    df = ts.get_stock_basics()
    df.to_sql("stock_basic", engine, if_exists = "replace", dtype = {"code":String(6), "name":String(8)})
    engine.execute("alter table stock_basic add primary key (code)")

def get_index():
	df = ts.get_index()
	df.to_sql("stock_index", engine, if_exists = "replace", dtype = {"code":String(6), "name":String(8)}, index = False)
	engine.execute("alter table stock_index add primary key (code)")

def get_today_all():
    df = ts.get_today_all()
    df.to_sql("stock_today_all", engine, if_exists = "replace", dtype = {"code":String(6), "name":String(8)}, index = False)
    engine.execute("alter table stock_today_all add primary key (code)")
    print("   Succeed in getting data...%s"%time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time())))

def perform_command(fun, inc):
    schedule.enter(inc, 0, perform_command, (fun, inc))
    fun()

def timming_exe(fun, inc = 60):
    schedule.enter(inc, 0, perform_command, (fun, inc))
    schedule.run()

def start_getting_data():
    get_today_all()
    timming_exe(get_today_all, 60)