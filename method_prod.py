from pyspark.sql import SparkSession
from pyspark.sql.functions import col

def get_product_category_pairs(spark: SparkSession):
    
    products = spark.table("products")
    categories = spark.table("categories")
    product_categories = spark.table("product_categories")

    
    product_category_pairs = products.join(product_categories, products.id == product_categories.product_id, 'left') \
        .join(categories, product_categories.category_id == categories.id, 'left')

   
    product_category_pairs = product_category_pairs.select(col("products.name").alias("product_name"), col("categories.name").alias("category_name"))

    
    products_without_categories = product_category_pairs.filter(col("category_name").isNull())

    return product_category_pairs, products_without_categories
