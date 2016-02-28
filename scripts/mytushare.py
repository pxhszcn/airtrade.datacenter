from sqlalchemy import *
import tushare as ts
def get_stock_basics():
    engine = create_engine('mysql://root:Root12345@127.0.0.1/stock_data?charset=utf8')
    df = ts.get_stock_basics()
    df.to_sql('stock_basic', engine, if_exists='replace', dtype={'code':String(6), 'name':String(8)})
    engine.execute('alter table stock_basic add primary key (code)')

def get_index():
	engine = create_engine('mysql://root:Root12345@127.0.0.1/stock_data?charset=utf8')
	df = ts.get_index()
	df.to_sql('stock_index', engine, if_exists='replace', dtype={'code':String(6), 'name':String(8)}, index=False)
	engine.execute('alter table stock_index add primary key (code)')