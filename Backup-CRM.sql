/*
SQLyog Community v13.2.1 (64 bit)
MySQL - 5.7.44 : Database - zordik
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`zordik` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `zordik`;

/*Table structure for table `accessories` */

DROP TABLE IF EXISTS `accessories`;

CREATE TABLE `accessories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `image` varchar(250) NOT NULL,
  `link` varchar(250) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `accessories` */

/*Table structure for table `address` */

DROP TABLE IF EXISTS `address`;

CREATE TABLE `address` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `phone` varchar(256) NOT NULL,
  `name` text NOT NULL,
  `house` text NOT NULL,
  `area` text NOT NULL,
  `landmark` text NOT NULL,
  `pincode` text NOT NULL,
  `city` text NOT NULL,
  `state` text NOT NULL,
  `country` text NOT NULL,
  `active_status` int(11) DEFAULT '0',
  `is_active` int(11) NOT NULL DEFAULT '1',
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

/*Data for the table `address` */

insert  into `address`(`id`,`user_id`,`phone`,`name`,`house`,`area`,`landmark`,`pincode`,`city`,`state`,`country`,`active_status`,`is_active`,`date`) values 
(9,7,'9876543215','Aakash Ruhal','7777','ggg','ggg','124001','Rohtak','Haryana','India',1,1,'2024-02-02 12:27:30'),
(13,7,'1254785496','Aakash','12','rohtak','rohtak','124001','Rohtak','Haryana','India',0,1,'2024-02-02 13:02:17'),
(14,7,'5555555555','ggg','4444','ggg','ggg','4444','Baghl?n','Baghlan','Afghanistan',0,1,'2024-02-09 11:35:17');

/*Table structure for table `admin` */

DROP TABLE IF EXISTS `admin`;

CREATE TABLE `admin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) NOT NULL,
  `role` varchar(256) NOT NULL,
  `email` varchar(256) NOT NULL,
  `password` varchar(256) NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` tinyint(4) NOT NULL,
  `deleted` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `admin` */

insert  into `admin`(`id`,`name`,`role`,`email`,`password`,`date`,`status`,`deleted`) values 
(1,'admin','1','admin@zordik.com','123','2023-09-06 00:00:00',1,1);

/*Table structure for table `banner` */

DROP TABLE IF EXISTS `banner`;

CREATE TABLE `banner` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `offer` varchar(255) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text,
  `url` varchar(255) DEFAULT NULL,
  `banner` varchar(255) DEFAULT NULL,
  `is_active` int(11) DEFAULT '1',
  `is_delete` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

/*Data for the table `banner` */

insert  into `banner`(`id`,`offer`,`title`,`description`,`url`,`banner`,`is_active`,`is_delete`) values 
(2,'Register and Get 10% off on First Order','New Collection','If you are looking for Latest home gadgets, then Zordik is the Best place','https://www.zordik.com/shop?cno=3','banner1700656760WhatsApp Image 2023-11-22 at 18.03.52_b4a3ccc2.jpg',1,0),
(3,'Big Offer 60% off','Summer Sale','Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ','shop','banner1699092236home1-slider1.png',1,0),
(4,'Big Offer 45% off','Summer Sale','Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ','shop','banner1699091325home2-slider1.png',1,0);

/*Table structure for table `blog` */

DROP TABLE IF EXISTS `blog`;

CREATE TABLE `blog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `blog_title` varchar(256) NOT NULL,
  `blog_description` longtext NOT NULL,
  `blog_thumbnail` varchar(256) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `blog` */

/*Table structure for table `brand` */

DROP TABLE IF EXISTS `brand`;

CREATE TABLE `brand` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `brand_name` varchar(256) NOT NULL,
  `brand_logo` varchar(256) NOT NULL,
  `deleted` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `brand` */

insert  into `brand`(`id`,`brand_name`,`brand_logo`,`deleted`) values 
(1,'ZORDIK','1700466849WhatsApp Image 2020-06-18 at 4.29.43 PM (2).jpeg',1);

/*Table structure for table `cart` */

DROP TABLE IF EXISTS `cart`;

CREATE TABLE `cart` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `variation_id` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `user_id` varchar(250) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8mb4;

/*Data for the table `cart` */

insert  into `cart`(`id`,`product_id`,`variation_id`,`qty`,`user_id`,`created_at`,`updated_at`) values 
(14,1,1,1,'_5ft8fjn6ln5111','2024-02-07 17:33:15','2024-02-07 17:33:15'),
(42,17,17,1,'7','2024-02-10 10:57:26','2024-02-10 10:57:26'),
(43,4,6,1,'7','2024-02-10 10:57:32','2024-02-10 10:57:32'),
(44,1,1,1,'7','2024-02-10 10:57:35','2024-02-10 10:57:35'),
(45,17,17,1,'7','2024-02-10 11:49:26','2024-02-10 11:49:26'),
(46,18,18,1,'7','2024-02-10 11:49:59','2024-02-10 11:49:59'),
(47,16,16,1,'7','2024-02-10 12:12:12','2024-02-10 12:12:12'),
(48,1,1,1,'7','2024-02-10 12:14:48','2024-02-10 12:14:48'),
(49,4,6,1,'_vtabhh48qxg111','2024-02-29 11:42:22','2024-02-29 11:42:22');

/*Table structure for table `category` */

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) NOT NULL,
  `slug` varchar(250) NOT NULL,
  `cat_image` text,
  `is_active` tinyint(4) NOT NULL DEFAULT '1',
  `created_datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_delete` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_cat_name` (`name`,`is_delete`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4;

/*Data for the table `category` */

insert  into `category`(`id`,`name`,`slug`,`cat_image`,`is_active`,`created_datetime`,`is_delete`) values 
(1,'KIDS SPECIAL','kids-special','8.png',1,'2023-12-07 00:00:00',0),
(2,'Electronics','electronics','7.png',1,'2023-12-07 00:00:00',1),
(3,'Stationery','stationery','5.png',1,'2023-12-07 00:00:00',0),
(4,'Beauty','beauty','2.png',1,'2024-01-26 00:00:00',1),
(5,'Fashion','fashion','1.png',1,'2024-01-26 00:00:00',1),
(6,'Accessories','accessories','3.png',1,'2024-01-26 00:00:00',0),
(7,'Health','health','4.png',1,'2024-01-26 00:00:00',0),
(8,'Baby Care','baby-care','6.png',0,'2024-01-26 00:00:00',0),
(9,'Sport','sport','8.png',1,'2024-01-26 00:00:00',0);

/*Table structure for table `color` */

DROP TABLE IF EXISTS `color`;

CREATE TABLE `color` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `color` varchar(256) NOT NULL,
  `is_active` int(11) NOT NULL DEFAULT '1',
  `is_delete` int(11) DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_color_name` (`color`,`is_delete`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

/*Data for the table `color` */

insert  into `color`(`id`,`color`,`is_active`,`is_delete`) values 
(1,'Multicolour',1,0),
(2,'Random Colour',1,0),
(3,'Green',1,0),
(4,'Red',1,0),
(5,'Blue',1,0),
(6,'White',1,1);

/*Table structure for table `contact` */

DROP TABLE IF EXISTS `contact`;

CREATE TABLE `contact` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `phone` bigint(20) NOT NULL,
  `email` varchar(256) NOT NULL,
  `address` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `contact` */

insert  into `contact`(`id`,`phone`,`email`,`address`) values 
(1,7583850085,'hello@crunchfitness.com','First Floor, Plot No-5 Bhwani Kunj, Vasant Kunj,\r\nNew Delhi,110070');

/*Table structure for table `coupon_code` */

DROP TABLE IF EXISTS `coupon_code`;

CREATE TABLE `coupon_code` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `coupon_name` varchar(256) NOT NULL,
  `coupon_value` varchar(256) NOT NULL,
  `coupon_type` varchar(256) NOT NULL,
  `cart_min_value` varchar(256) NOT NULL,
  `expiry_date` varchar(256) NOT NULL,
  `status` tinyint(4) NOT NULL,
  `deleted` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `coupon_code` */

insert  into `coupon_code`(`id`,`coupon_name`,`coupon_value`,`coupon_type`,`cart_min_value`,`expiry_date`,`status`,`deleted`) values 
(1,'Christmas Sale','10','percentage','1000','2023-12-31',1,1);

/*Table structure for table `deal_of_the_day` */

DROP TABLE IF EXISTS `deal_of_the_day`;

CREATE TABLE `deal_of_the_day` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `offer` varchar(255) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text,
  `url` varchar(255) DEFAULT NULL,
  `banner` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

/*Data for the table `deal_of_the_day` */

insert  into `deal_of_the_day`(`id`,`offer`,`title`,`description`,`url`,`banner`) values 
(1,'Hurry up and Get 25% Discount','Deals Of The Day','Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do ','shop','banner1699096106banner-bg1.png');

/*Table structure for table `home_banner` */

DROP TABLE IF EXISTS `home_banner`;

CREATE TABLE `home_banner` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `left_img_main_heading` varchar(100) DEFAULT NULL,
  `left_img_sub_heading` varchar(100) DEFAULT NULL,
  `left_img_text` varchar(100) DEFAULT NULL,
  `left_img` varchar(100) DEFAULT NULL,
  `left_img_button` varchar(100) DEFAULT NULL,
  `middle_img_main_heading` varchar(100) DEFAULT NULL,
  `middle_img_sub_heading` varchar(100) DEFAULT NULL,
  `middle_img` varchar(100) DEFAULT NULL,
  `middle_img_button` varchar(100) DEFAULT NULL,
  `top_right_img_main_heading` varchar(100) DEFAULT NULL,
  `top_right_img_sub_heading` varchar(100) DEFAULT NULL,
  `top_right_img` varchar(100) DEFAULT NULL,
  `bottom_right_main_heading` varchar(100) DEFAULT NULL,
  `botton_right_sub_heading` varchar(100) DEFAULT NULL,
  `bottom_right_img` varchar(100) DEFAULT NULL,
  `is_active` int(11) DEFAULT '1',
  `is_delete` int(11) DEFAULT '0',
  `created_datetime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `home_banner` */

insert  into `home_banner`(`id`,`left_img_main_heading`,`left_img_sub_heading`,`left_img_text`,`left_img`,`left_img_button`,`middle_img_main_heading`,`middle_img_sub_heading`,`middle_img`,`middle_img_button`,`top_right_img_main_heading`,`top_right_img_sub_heading`,`top_right_img`,`bottom_right_main_heading`,`botton_right_sub_heading`,`bottom_right_img`,`is_active`,`is_delete`,`created_datetime`) values 
(1,'100% Fresh','Fruit & Vegetables','Free shipping on all your order. we deliver you enjoy','1.png',NULL,'Fresh & 100% Organic','Famer\'s market','2.png',NULL,'Organic Lifestyle','Best Weekend Sales','3.png','Safe food saves lives','Discount Offer','4.png',1,0,'2024-02-01 15:41:32');

/*Table structure for table `image-gallery` */

DROP TABLE IF EXISTS `image-gallery`;

CREATE TABLE `image-gallery` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `p_id` int(11) NOT NULL,
  `image` varchar(256) NOT NULL,
  `date` date NOT NULL,
  `deleted` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4;

/*Data for the table `image-gallery` */

insert  into `image-gallery`(`id`,`p_id`,`image`,`date`,`deleted`) values 
(1,1,'01701933490Untitled design (17).png','2023-12-07',1),
(2,1,'117019334901 (1).png','2023-12-07',1),
(3,1,'217019334915 (1).png','2023-12-07',1),
(4,1,'317019334914 (1).png','2023-12-07',1),
(5,1,'417019334913 (1).png','2023-12-07',1),
(6,2,'0170193441361IEUNaWGmL._SY879_.jpg','2023-12-07',1),
(7,2,'11701934413611EFK88kuL._SY879_.jpg','2023-12-07',1),
(8,2,'21701934413513yF6cOPwL._SY879_.jpg','2023-12-07',1),
(9,2,'3170193441351q1poGem3L._SX679_.jpg','2023-12-07',1),
(10,2,'4170193441341yjYSqOARL._SX679_.jpg','2023-12-07',1),
(11,3,'01701935328IMG-20231125-WA0010.jpg','2023-12-07',1),
(12,3,'11701935328IMG-20231125-WA0009.jpg','2023-12-07',1),
(13,3,'21701935328IMG-20231125-WA0008.jpg','2023-12-07',1),
(14,3,'31701935328IMG-20231125-WA0007.jpg','2023-12-07',1),
(15,3,'41701935328IMG-20231125-WA0006.jpg','2023-12-07',1),
(16,3,'01701935920319Tw4ooI4L.jpg','2023-12-07',1),
(17,5,'0170305495841eTPdxJ6NL.jpg','2023-12-20',1),
(18,5,'1170305495851o1lkVF++L.jpg','2023-12-20',1),
(19,5,'2170305495851wPmPi8MML.jpg','2023-12-20',1),
(20,5,'3170305495861Q4zXNR-+L._SL1280_.jpg','2023-12-20',1),
(21,5,'4170305495861XeqkNNnzL._SL1200_.jpg','2023-12-20',1),
(22,5,'51703054958613k0E9G++L.jpg','2023-12-20',1),
(23,5,'61703054958615mWR6Sa6L._SL1280_.jpg','2023-12-20',1);

/*Table structure for table `order` */

DROP TABLE IF EXISTS `order`;

CREATE TABLE `order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `payment_id` varchar(256) DEFAULT NULL,
  `user_id` varchar(256) NOT NULL,
  `address_id` int(11) NOT NULL,
  `total_amount` double NOT NULL,
  `gst` double NOT NULL,
  `shipping` double NOT NULL,
  `order_status` int(11) NOT NULL DEFAULT '1',
  `order_cancel` int(11) NOT NULL DEFAULT '0',
  `order_cancel_reason` varchar(200) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `tracking_id` text,
  `courier_name` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

/*Data for the table `order` */

insert  into `order`(`id`,`payment_id`,`user_id`,`address_id`,`total_amount`,`gst`,`shipping`,`order_status`,`order_cancel`,`order_cancel_reason`,`created_at`,`tracking_id`,`courier_name`) values 
(7,'cod','7',1,380,32.14,80,4,0,'Order placed by mistake','2024-02-07 15:40:44',NULL,NULL),
(8,'0','7',1,330,11.9,80,0,0,NULL,'2024-02-07 16:25:36',NULL,NULL),
(10,'pay_NXxwb1VmGxgLxr','7',1,100,3.05,80,1,0,NULL,'2024-02-07 16:30:51',NULL,NULL),
(11,'pay_NXxz1UI93Yw2T2','7',1,380,32.14,80,1,0,NULL,'2024-02-07 16:33:23',NULL,NULL),
(12,'0','7',1,100,3.05,80,0,0,NULL,'2024-02-07 16:39:04',NULL,NULL),
(13,'0','7',1,160,8.57,80,0,0,NULL,'2024-02-07 16:41:54',NULL,NULL),
(14,'pay_NYMrp5YdY6YG9t','7',1,480,42.86,80,1,0,NULL,'2024-02-07 16:45:39',NULL,NULL);

/*Table structure for table `order_items` */

DROP TABLE IF EXISTS `order_items`;

CREATE TABLE `order_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `orderid` int(11) NOT NULL,
  `productid` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `price` bigint(20) NOT NULL,
  `color` varchar(256) NOT NULL,
  `size` varchar(2256) NOT NULL,
  `variation_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;

/*Data for the table `order_items` */

insert  into `order_items`(`id`,`orderid`,`productid`,`qty`,`price`,`color`,`size`,`variation_id`) values 
(6,7,9,1,0,'','',9),
(7,8,8,1,0,'','',8),
(8,10,3,1,0,'','',5),
(9,11,9,1,0,'','',9),
(10,12,3,1,0,'','',5),
(11,13,13,1,0,'','',13),
(12,14,11,1,0,'','',11);

/*Table structure for table `product-video` */

DROP TABLE IF EXISTS `product-video`;

CREATE TABLE `product-video` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `p_id` int(11) NOT NULL,
  `video` varchar(256) NOT NULL,
  `date` varchar(256) NOT NULL,
  `deleted` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `product-video` */

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cat_id` int(11) NOT NULL,
  `sub_cat_id` int(11) NOT NULL,
  `brand_id` int(11) NOT NULL,
  `name` text NOT NULL,
  `short_description` text NOT NULL,
  `description` longtext NOT NULL,
  `slug` varchar(256) NOT NULL,
  `image` varchar(256) NOT NULL,
  `sku_code` varchar(256) NOT NULL,
  `hsn_code` varchar(256) NOT NULL,
  `product_brand` varchar(256) NOT NULL,
  `gst` int(11) NOT NULL,
  `cod` tinyint(4) NOT NULL,
  `product_weight` varchar(256) NOT NULL,
  `shipping_weight` varchar(256) NOT NULL,
  `dispatch_time` varchar(256) NOT NULL,
  `delivery_time` varchar(256) NOT NULL,
  `packed_by` varchar(256) NOT NULL,
  `manufactured_by` varchar(256) NOT NULL,
  `video_link` text NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_active` int(11) NOT NULL DEFAULT '1',
  `is_delete` int(11) NOT NULL DEFAULT '0',
  `best_seller` int(11) NOT NULL DEFAULT '0',
  `featured_products` int(11) NOT NULL DEFAULT '0',
  `discounted_products` int(11) NOT NULL DEFAULT '0',
  `new_arrival` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4;

/*Data for the table `products` */

insert  into `products`(`id`,`cat_id`,`sub_cat_id`,`brand_id`,`name`,`short_description`,`description`,`slug`,`image`,`sku_code`,`hsn_code`,`product_brand`,`gst`,`cod`,`product_weight`,`shipping_weight`,`dispatch_time`,`delivery_time`,`packed_by`,`manufactured_by`,`video_link`,`date`,`is_active`,`is_delete`,`best_seller`,`featured_products`,`discounted_products`,`new_arrival`) values 
(1,1,1,1,'Zordik- Mini Bus Water Dispenser with 10 Cotton Clay Toy Trendy Moving Wheels School Bus car Toy with Mini Water Dispenser Tank for Kids (Green)','Compact Mini Bus Water Dispenser with 10 Cotton Clay filters, ensuring pure, refreshing drinks on-the-go. Sleek design, durable, user-friendly.','<p>Zordik Mini Bus Water Dispenser with 10 Cotton Clay filters offers on-the-go hydration. Tailored for mini buses, it ensures passengers easy access to refreshing drinks during journeys. With a sleek design and durable construction, it seamlessly fits into any vehicle interior. The compact size allows effortless installation, a practical addition to any mini bus. Crafted from premium materials, the filters enhance water taste and quality by removing impurities, chlorine, and odors. The user-friendly dispenser, featuring a simple push-button mechanism and cooling system, ensures a satisfying drink on extended journeys. With a generous water tank capacity, it caters to multiple servings before a refill is needed. Experience pure and healthy hydration with Zordik.</p>\r\n','zordik--mini-bus-water-dispenser-with-10-cotton-clay-toy-trendy-moving-wheels-school-bus-car-toy-with-mini-water-dispenser-tank-for-kids-green-','19.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','https://pdfresizer.com/merge/e0d1a06371cf.pdf%2Ca40a034c1ee6.pdf','2023-12-07 12:47:46',1,0,1,0,1,1),
(2,1,1,1,'ZORDIK Black Panther Avengers Hero Action Figure Set with Movable arm, Legs, Body Parts with Light | (Pack of 1)â€¦','Explore endless adventures with the Black Panther action figure! Perfect for kids, this toy brings the excitement of Wakanda to life with detailed design and poseable features like led light and unbreakable plastic body.','<p>Marvel Black panther Super Hero journey toys and play sets square measure sized right for tiny hands they create fun gifts for teenagers whether or not they&rsquo;re new Marvel fans or already collect Marvel toys creative PLAY: With this action figure set, youngsters ages three and up will interact in creative play, recreating the fun of their favorite scenes from the moving-picture show and imagining their own adventures. The time Stone Color are Send totally different. As Per Purple, Yellow, inexperienced &amp; Orange. Black Panther 6-Inch scale Black Panther figure &ndash; Imagine Black Panther victimisation her energy-blasting talents to require down villains with this 6-inch-scale Black Panther figure, impressed by the Avengers: Endgame moving-picture show Movie-based, character-inspired accent &ndash; this Marvel action figure includes a Black Panther -inspired blast result accent that produces a good addition to any Marvel figure and vehicle assortment Marvel movie-inspired style &ndash; fans will imagine action-packed scenes with this Black Panther figure, impressed by Avengers: Endgame from the Marvel medium universe Articulation and particularization &ndash; Marvel fans will imagine the Avengers: Endgame excitement with this pose-able Black Panther figure, that includes articulated arms and head and movie-inspired Collect a Marvel universe &ndash; search for alternative Marvel toys and figures</p>\r\n','zordik-black-panther-avengers-hero-action-figure-set-with-movable-arm-legs-body-parts-with-light-pack-of-1-','21.jpg','Black panther','9503','',12,1,'90','20','2','5','Zordik','Zordik','','2023-12-07 13:02:06',1,0,1,1,0,0),
(3,2,2,1,'Zordik- Washing Machine Pads- Vibration pads & Heightening Pads with Suction -Wardrobe, Fridge, Study Table, Sofa','Zordik Anti-Vibration Washing Machine Pads provide stability and noise reduction.\r\nProtect your home from vibrations, ensuring a quiet and smooth laundry experience. Easy installation for peace of mind.','<p>Zordik India-Washing Machine Pads - the ultimate solution to eliminate vibrations and customize the height of your appliances. Say goodbye to noisy, shaky appliances with these innovative pads. They offer powerful vibration dampening, easy height adjustments, and exceptional stability with their strong suction cups. Use them under your washing machine, wardrobe, fridge, study table, or sofa, and enjoy a quieter and more organized home. Installation is a breeze, and these durable pads will provide long-lasting peace and stability.</p>\r\n\r\n<p>-Effective vibration dampening<br />\r\n-Easy appliance height adjustments<br />\r\n-Strong suction cups for stability<br />\r\n-Versatile use for various appliances<br />\r\n-Simple installation, no tools required<br />\r\n-Durable, long-lasting materials<br />\r\n-Transform your home into a peaceful haven</p>\r\n','zordik--washing-machine-pads--vibration-pads-heightening-pads-with-suction--wardrobe-fridge-study-table-sofa','21.jpg','Washing Machine Pads','4016','',18,1,'85','30','2','5','ZORDIK INDIA','Zordik','','2023-12-07 13:18:22',1,0,0,1,1,0),
(4,3,3,1,' ZORDIK Unicorn Print Documents File Folder | A4 Size Five Pocket Certificates Paper Organizer for School and Office | Multi Color (Pack of 2)','Elevate organization with Unicorn File Folders â€“ 2 Pieces. Whimsical and functional, these folders add a touch of magic to your filing system. Stay organized in enchanting style!','<p>Bright, Cute, well Designed and Easy to Close. Expanding File Folder A4 Letter Size 5 Pockets Accordion Folder Organizer Blue Waterproof Zipper File Bag , You Can Be Sure You&rsquo;ve Found the Perfect Expanding File Folder Which Is Practical in Classifying and Storing Papers, with Convenient Large Storage Space, Able to Store All Documents, Files, Materials, and Other Office Supplies. File Folder Is Valuable and Functional, Makes It Easy to Get Organized. Is Perfect for Your Everyday Organizational Need. Our Product Can Be Used As: Paper Organizer, File Folder, File Organizer, Organizer for Paper, File Folder Organizer, File Filter, Document Organizer, Tabbed Paper Organizer, Folder Organizer, Accordion File Organizer, Receipt Organizer, Folder Case, Personal Files, Basic File Organizer, Accordion File, Coupon File Accordion, Document Folder, Multiple Folder Organizer, Cabinet Organizer Paper, Multi Pocket Folder, Receipt Keeper, Month Folder, Travel File Organizer. Product Dimensions :- 32.5 X 23.5 X 5.2 (L X W X H) centimeter.</p>\r\n','-zordik-unicorn-print-documents-file-folder-a4-size-five-pocket-certificates-paper-organizer-for-school-and-office-multi-color-pack-of-2-','21.jpg','3924','','',18,1,'100','120','2','5','ZORDIK INDIA','Zordik','NA','2023-12-07 13:28:07',1,0,1,0,1,0),
(5,3,4,1,'Helicopter Perfume','klfhsdjahgkjhkjbkjl','<p>dsjhjkaskjdbk;ajhds;kjahn</p>\r\n','helicopter-perfume','18.jpg','HPPP','8518','',18,1,'100','120','1','5','Zordik India','ZORDIK RETAIL INDIA PVT LTD','https://www.youtube.com/watch?v=AIr1EIEcNik','2023-12-20 12:18:28',1,0,0,1,0,1),
(6,1,1,1,'car','gffdg','','car','20.webp','sku999','5643','',5,1,'350','400','1','1','rahul','zordik','','2023-12-21 15:15:28',1,0,1,0,1,0),
(7,1,1,1,'Car','Toy Car for kids','<p>Toy Car for kids</p>\r\n','car','20.webp','5346','1232','',12,1,'300','400','1','1','rahul','zordik','','2023-12-21 16:58:32',1,0,1,1,0,1),
(8,3,0,1,'Bell Pepper',' Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?','bell-pepper','1.png','5346','1232','',5,1,'200','200','1','1','rahul','zordik','','2024-01-26 16:02:44',1,0,0,0,1,0),
(9,5,0,1,'Potato','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','potato','3.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,0,1,1,0),
(10,4,0,1,'Baby Chili','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','baby-chili','5.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,1,0,0,1),
(11,4,0,1,'Broccoli','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','broccoli','6.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,0,1,1,0),
(12,6,0,1,'Peru','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','peru','7.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,1,0,0,1),
(13,9,0,1,'Avacado','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','avacodo','9.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,0,0,1,1),
(14,7,0,1,'Cucumber','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','cucumber','11.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,1,1,0,0),
(15,7,0,1,'Beetroot','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','beetroot','12.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,0,1,0,1),
(16,6,0,1,'Strawberry','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','strawberry','13.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,1,0,1,1),
(17,9,0,1,'Corn','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','Corn','15.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,0,1,0,1),
(18,6,0,1,'Cabbage','Lorem ipsum dolor sit, amet consectetur adipisicing elit. Maxime recusandae fuga consectetur animi, fugit possimus?','<p> Lorem ipsum dolor, sit amet consectetur adipisicing elit. Debitis voluptate nesciunt incidunt fugit inventore nemo, necessitatibus eius, quae ut enim aperiam possimus harum repudiandae repellat odit corporis totam aliquid sit doloribus. Officiis itaque cum fugit molestiae accusamus facilis, commodi fugiat adipisci nobis nam, qui eaque, impedit doloribus nisi libero possimus ipsum ab? Officia architecto harum earum, ipsum, recusandae amet quidem porro labore inventore sit voluptates quasi aliquam quo vitae nesciunt reiciendis beatae aliquid iusto veritatis culpa quisquam dolores sint nisi. Earum facere quo aperiam quasi ducimus nulla omnis sunt quam! Quas, inventore laborum. Dolore voluptates doloribus cumque modi, eum atque?</p>\r\n','cabbage','17.png','9503','','',12,1,'150','200','1','5','Zordik India','Zordik','','2023-12-07 12:47:46',1,0,1,1,1,0);

/*Table structure for table `review` */

DROP TABLE IF EXISTS `review`;

CREATE TABLE `review` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `description` longtext NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

/*Data for the table `review` */

insert  into `review`(`id`,`user_id`,`product_id`,`description`,`created_at`) values 
(1,5,1,'Best Product','2024-02-01 12:11:22'),
(2,7,2,'Product Is Awesome','2024-02-01 12:17:58');

/*Table structure for table `shop_transaction` */

DROP TABLE IF EXISTS `shop_transaction`;

CREATE TABLE `shop_transaction` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `payment_id` varchar(200) NOT NULL,
  `payment_request_id` varchar(200) NOT NULL,
  `payment_status` varchar(200) NOT NULL,
  `user_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `deleted` int(11) NOT NULL DEFAULT '1',
  `ordered_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `shop_transaction` */

/*Table structure for table `size` */

DROP TABLE IF EXISTS `size`;

CREATE TABLE `size` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `size` varchar(256) NOT NULL,
  `is_active` tinyint(4) NOT NULL DEFAULT '1',
  `is_delete` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_size` (`size`,`is_delete`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

/*Data for the table `size` */

insert  into `size`(`id`,`size`,`is_active`,`is_delete`) values 
(1,'Free Size',1,0),
(2,'2 x 2',1,0),
(3,'3 x 3',1,0),
(4,'4 x 4',1,0),
(5,'5 x 5',1,0),
(6,'6 x 6',1,1);

/*Table structure for table `sub_category` */

DROP TABLE IF EXISTS `sub_category`;

CREATE TABLE `sub_category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cat_id` int(11) NOT NULL,
  `name` varchar(256) NOT NULL,
  `slug` varchar(250) NOT NULL,
  `is_active` tinyint(4) NOT NULL DEFAULT '1',
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_delete` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_subcat_name` (`name`,`is_delete`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

/*Data for the table `sub_category` */

insert  into `sub_category`(`id`,`cat_id`,`name`,`slug`,`is_active`,`created_at`,`is_delete`) values 
(1,1,'TOYS','toys',1,'2023-12-07 00:00:00',0),
(2,6,'HOME ACCESSORIES','home-accessories',1,'2023-12-07 00:00:00',0),
(3,3,'STATIONERY PRODUCTS','file-folders',1,'2023-12-07 00:00:00',0),
(4,3,'CAR ACCESSORIES','car-accessories',1,'2023-12-20 00:00:00',0),
(5,1,'car','car',1,'2024-03-28 15:40:10',1),
(10,1,'car','car',1,'2024-03-29 15:42:47',0);

/*Table structure for table `top-stories` */

DROP TABLE IF EXISTS `top-stories`;

CREATE TABLE `top-stories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `header` varchar(256) NOT NULL,
  `image` varchar(256) NOT NULL,
  `date` date NOT NULL,
  `status` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `top-stories` */

/*Table structure for table `user_enquiry` */

DROP TABLE IF EXISTS `user_enquiry`;

CREATE TABLE `user_enquiry` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) NOT NULL,
  `email` varchar(256) NOT NULL,
  `phone` bigint(20) NOT NULL,
  `message` longtext NOT NULL,
  `deleted` int(11) NOT NULL DEFAULT '1',
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `user_enquiry` */

/*Table structure for table `userdata` */

DROP TABLE IF EXISTS `userdata`;

CREATE TABLE `userdata` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) NOT NULL,
  `email` varchar(256) NOT NULL,
  `phone` bigint(20) NOT NULL,
  `password` varchar(256) NOT NULL,
  `referral_code` bigint(20) NOT NULL,
  `sponsored_by` bigint(20) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

/*Data for the table `userdata` */

insert  into `userdata`(`id`,`name`,`email`,`phone`,`password`,`referral_code`,`sponsored_by`,`created_at`,`modified_at`) values 
(7,'User','user@gmail.com',123456789,'ee11cbb19052e40b07aac0ca060c23ee',0,0,'2024-01-10 17:35:39','2024-01-10 17:35:39'),
(8,'pankaj','pankaj@gmail.com',1234565482,'95deb5011a8fe1ccf6552bb5bcda2ff0',0,0,'2024-01-10 17:38:21','2024-01-10 17:38:21'),
(9,'Aakash','aakash@gmail.com',1234567890,'a870c4012ce2eaa3b60a4c59cb786f76',0,0,'2024-01-25 14:53:01','2024-01-25 14:53:01'),
(10,'Aman','aman@gmail.com',123485210,'0363212ba373b3a4d56e85b9146ae2a8',0,0,'2024-01-25 15:06:34','2024-01-25 15:06:34');

/*Table structure for table `variation` */

DROP TABLE IF EXISTS `variation`;

CREATE TABLE `variation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `size_id` int(11) NOT NULL,
  `color_id` int(11) NOT NULL,
  `mrp` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `image` varchar(256) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4;

/*Data for the table `variation` */

insert  into `variation`(`id`,`product_id`,`size_id`,`color_id`,`mrp`,`price`,`qty`,`image`) values 
(1,1,1,1,1000,100,10,'1.png'),
(2,1,2,2,2000,200,10,'2.png'),
(3,2,2,2,3000,300,10,'3.png'),
(4,2,4,4,4000,400,10,'4.png'),
(5,3,1,1,499,20,8,'5.png'),
(6,4,5,5,999,499,10,'5.png'),
(7,7,1,1,1200,800,10,'170315888661Z4WVfP3wL._SX522_.jpg'),
(8,8,1,1,299,250,9,'1.jpg'),
(9,9,1,1,399,300,8,'1.jpg'),
(10,10,1,1,199,120,10,'1.jpg'),
(11,11,1,1,499,400,9,'1.jpg'),
(12,12,1,1,149,100,10,'1.jpg'),
(13,13,1,1,99,80,9,'1.jpg'),
(14,14,1,1,249,230,9,'1.jpg'),
(15,15,1,1,399,350,10,'1.jpg'),
(16,16,1,1,99,90,10,'1.jpg'),
(17,17,1,1,199,140,10,'1.jpg'),
(18,18,1,1,599,520,10,'1.jpg');

/*Table structure for table `variation_image` */

DROP TABLE IF EXISTS `variation_image`;

CREATE TABLE `variation_image` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `variation_id` int(11) DEFAULT NULL,
  `variation_img` varchar(256) DEFAULT NULL,
  `is_active` int(11) DEFAULT '1',
  `is_delete` int(11) DEFAULT '0',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `variation_image` */

insert  into `variation_image`(`id`,`variation_id`,`variation_img`,`is_active`,`is_delete`,`created_at`) values 
(1,1,'1.png',1,0,'2024-02-06 15:13:23'),
(2,1,'2.png',1,0,'2024-02-06 15:13:34'),
(3,1,'3.png',1,0,'2024-02-06 15:13:42'),
(4,2,'4.png',1,0,'2024-02-06 15:13:57'),
(5,3,'5.png',1,0,'2024-02-06 15:14:07');

/*Table structure for table `wishlist` */

DROP TABLE IF EXISTS `wishlist`;

CREATE TABLE `wishlist` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `variation_id` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `user_id` varchar(250) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4;

/*Data for the table `wishlist` */

insert  into `wishlist`(`id`,`product_id`,`variation_id`,`qty`,`user_id`,`created_at`,`updated_at`) values 
(3,1,1,1,'1','2024-01-30 17:07:01','2024-01-30 17:07:03'),
(25,13,13,1,'7','2024-02-10 12:12:32','2024-02-10 12:12:32');

/* Procedure structure for procedure `AddProductReview` */

/*!50003 DROP PROCEDURE IF EXISTS  `AddProductReview` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `AddProductReview`(
	in SPUserID int,
	in SPProductID int,
	in SPReview text
	
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		BEGIN
			GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
		END;
		
		begin
			insert into `review` (user_id, product_id, description)
			values(SPUserID, SPProductID, SPReview);
		End;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		ELSE
			SELECT 1 AS ResponseCode, 'Review Added Successfully!' AS ResponseMessage;
			
		END IF;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `AdminLogin` */

/*!50003 DROP PROCEDURE IF EXISTS  `AdminLogin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `AdminLogin`(
	IN SPEmail VARCHAR(50),
	iN SPPassword VARCHAR(50)
)
BEGIN
	DECLARE user_count INT;		
	
	begin	
		SELECT COUNT(*) INTO user_count FROM `admin` WHERE `email` = SPEmail AND `password` = SPPassword;
	
		IF user_count > 0 THEN
			SELECT 1 AS ResponseCode, 'login success' AS ResponseMessage;
			SELECT * FROM `admin` WHERE `email` = SPEmail;			
		ELSE
			SELECT 0 AS ResponseCode, 'User Not Exist!' AS ResponseMessage;
		END IF;
	End;
	
			
END */$$
DELIMITER ;

/* Procedure structure for procedure `ClearCartData` */

/*!50003 DROP PROCEDURE IF EXISTS  `ClearCartData` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `ClearCartData`(
	in SPUserId int
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		begin
			GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
		End;
		
		begin
			Delete from `cart` where `user_id` = SPUserId;
		end;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		else
			Select 1 as ResponseCode, 'Cart Clear Successfully!' as ResponseMessage;
		END IF;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `CreateUserOrder` */

/*!50003 DROP PROCEDURE IF EXISTS  `CreateUserOrder` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `CreateUserOrder`(
    IN SPUserId INT,
    IN SPPaymentId VARCHAR(100),
    IN SPAddressId INT,
    IN SPTotalAmt DOUBLE,
    IN SPGstAmt DOUBLE,
    IN SPShippingAmt DOUBLE
)
BEGIN
    DECLARE custom_error_message VARCHAR(255);
    DECLARE order_id INT;
    DECLARE TotalQty INT;

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;

    START TRANSACTION;

    -- Insert into order table
    INSERT INTO `order`(`payment_id`, `user_id`, `address_id`, `total_amount`, `gst`, `shipping`)
    VALUES (SPPaymentId, SPUserId, SPAddressId, SPTotalAmt, SPGstAmt, SPShippingAmt);

    -- Get the last inserted order_id
    SET order_id = LAST_INSERT_ID();    
    

    -- Insert cart items into order_items table with the obtained order_id
    INSERT INTO `order_items` (`orderid`, `productid`, `qty`, `variation_id`)
    SELECT order_id, product_id, qty, variation_id
    FROM `cart`
    WHERE user_id = SPUserId;


    -- Update product stock qty
    UPDATE variation as v
    INNER JOIN cart as c ON v.id = c.variation_id
    SET v.qty = v.qty - c.qty
    WHERE c.user_id = SPUserId;

    -- Delete Cart Items of User
    DELETE FROM `cart` WHERE `user_id` = SPUserId;

    -- Check for errors
    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
        ROLLBACK;
    ELSE
        SELECT 1 AS ResponseCode, 'Order Placed Successfully!' AS ResponseMessage;
        select order_id;
        COMMIT;
    END IF;
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteAddress` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteAddress` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteAddress`(
	IN SPAddressId INT
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN	
		delete from `address` where `id` = SPAddressId;
	END;
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	ELSE
		if Row_Count() = 0 Then
			SELECT 0 AS ResponseCode, 'Address Not Found!' AS ResponseMessage;
		else
			SELECT 1 AS ResponseCode, 'Address Removed Successfully!' AS ResponseMessage;
		end if;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteCartItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteCartItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteCartItem`(
	in SPCartId int,
	in SPUserId varchar(50)
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		begin
			GET DIAGNOSTICS CONDITION 1
			custom_error_message = MESSAGE_TEXT;
		End;
		
		begin
			Delete from `cart` where `id` = SPCartId;
		end;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		else
			Select 1 as ResponseCode, 'Product Remove From Cart Successfully!' as ResponseMessage;
			
			SELECT COUNT(id) AS cart_count FROM `cart` WHERE user_id = SPUserId;
		END IF;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteCategory`(    
    IN SPCat_id INT
)
BEGIN
    DECLARE custom_error_message VARCHAR(255);
    DECLARE ref_count INT;

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
    END;

    SELECT COUNT(cat_id) INTO ref_count FROM sub_category WHERE `is_delete` = 0 and cat_id = SPCat_id;
    
    IF ref_count = 0 THEN
        UPDATE `category` SET `is_delete` = 1 WHERE `id` = SPCat_id;
    END IF;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        IF ref_count > 0 THEN
            SELECT 0 AS ResponseCode, 'Category cannot be deleted as it is referenced by subcategories.' AS ResponseMessage;
        ELSE
            SELECT 1 AS ResponseCode, 'Category Delete Successfully!' AS ResponseMessage;
        END IF;
    END IF;    
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteColor` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteColor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteColor`(    
    IN SPColor_id INT
)
BEGIN
    DECLARE custom_error_message VARCHAR(255);
    DECLARE ref_count INT;

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
    END;

    SELECT COUNT(`color_id`) INTO ref_count FROM `variation` WHERE `color_id` = SPColor_id;
    
    IF ref_count = 0 THEN
        UPDATE `color` SET `is_delete` = 1 WHERE `id` = SPColor_id;
    END IF;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        IF ref_count > 0 THEN
            SELECT 0 AS ResponseCode, 'Color cannot be deleted as it is referenced by product variations.' AS ResponseMessage;
        ELSE
            SELECT 1 AS ResponseCode, 'Color Delete Successfully!' AS ResponseMessage;
        END IF;
    END IF;    
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteRecord` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteRecord` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteRecord`(	
	in SPId int,
	in SPTableName varchar(256)
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;  

	BEGIN
		SET @sql = CONCAT('UPDATE ', SPTableName, ' SET is_delete = 1', ' WHERE id = ', SPId);
		PREPARE stmt FROM @sql;
		EXECUTE stmt;
		DEALLOCATE PREPARE stmt;
	END;    
    
    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Record Delete Successfully' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteSize` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteSize` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteSize`(    
    IN SPSizeId INT
)
BEGIN
    DECLARE custom_error_message VARCHAR(255);
    DECLARE ref_count INT;

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
    END;

    SELECT COUNT(`size_id`) INTO ref_count FROM `variation` WHERE `size_id` = SPSizeId;
    
    IF ref_count = 0 THEN
        UPDATE `size` SET `is_delete` = 1 WHERE `id` = SPSizeId;
    END IF;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        IF ref_count > 0 THEN
            SELECT 0 AS ResponseCode, 'Size cannot be deleted as it is referenced by product variations.' AS ResponseMessage;
        ELSE
            SELECT 1 AS ResponseCode, 'Size Delete Successfully!' AS ResponseMessage;
        END IF;
    END IF;    
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteSubCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteSubCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteSubCategory`(	
	in SPSubCat_id int
)
BEGIN
    DECLARE custom_error_message VARCHAR(255);
    DECLARE ref_count INT;

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
    END;

    SELECT COUNT(sub_cat_id) INTO ref_count FROM products WHERE `is_delete` = 0 AND sub_cat_id = SPSubCat_id;
    
    IF ref_count = 0 THEN
        UPDATE `sub_category` SET `is_delete` = 1 WHERE `id` = SPSubCat_id;
    END IF;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        IF ref_count > 0 THEN
            SELECT 0 AS ResponseCode, 'Sub-category cannot be deleted as it is referenced by products.' AS ResponseMessage;
        ELSE
            SELECT 1 AS ResponseCode, 'Sub-category Delete Successfully!' AS ResponseMessage;
        END IF;
    END IF;    
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteWishlistItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteWishlistItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `DeleteWishlistItem`(
	IN SPWishlistId INT,
	IN SPUserId VARCHAR(50)
)
BEGIN

		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		BEGIN
			GET DIAGNOSTICS CONDITION 1
			custom_error_message = MESSAGE_TEXT;
		END;
		
		BEGIN
			DELETE FROM `wishlist` WHERE `id` = SPWishlistId;
		END;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		ELSE
			SELECT 1 AS ResponseCode, 'Product Remove from Wishlist Successfully!' AS ResponseMessage;
			
			SELECT COUNT(id) AS wishlist_count FROM `wishlist` WHERE user_id = SPUserId;
		END IF;

END */$$
DELIMITER ;

/* Procedure structure for procedure `FetchCategoryForAdmin` */

/*!50003 DROP PROCEDURE IF EXISTS  `FetchCategoryForAdmin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `FetchCategoryForAdmin`(
	
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		Select * from `category` where is_delete = 0;
	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `FetchColorForAdmin` */

/*!50003 DROP PROCEDURE IF EXISTS  `FetchColorForAdmin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `FetchColorForAdmin`(
	
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT * FROM `color` WHERE is_delete = 0;
	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `FetchSizeForAdmin` */

/*!50003 DROP PROCEDURE IF EXISTS  `FetchSizeForAdmin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `FetchSizeForAdmin`(
	
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT * FROM `size` WHERE is_delete = 0;
	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetAllCategory`(
	
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		Select * from `category` where is_active = 1 AND is_delete = 0;
	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllColors` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllColors` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetAllColors`(
	
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT * FROM `color` WHERE is_active = 1 AND is_delete = 0;
	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllProduct` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllProduct` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetAllProduct`(
	IN SPLimit INT
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	IF SPLimit <> 0 THEN
	
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT p.id, p.name, p.slug, p.image, p.cat_id, cat.name as product_category, v.id AS variation_id, v.mrp, v.price, v.qty
		FROM products AS p
		JOIN (SELECT MIN(id) AS variation_id, product_id FROM variation GROUP BY product_id) AS min_var ON p.id = min_var.product_id
		JOIN variation AS v ON min_var.variation_id = v.id
		join category as cat on p.cat_id = cat.id
		WHERE p.is_active = 1 AND p.is_delete = 0
		ORDER BY RAND()
		LIMIT SPLimit;

        END IF;
        
        
        IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllSizes` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllSizes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetAllSizes`(
	
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT * FROM `size` WHERE is_active = 1 AND is_delete = 0;
	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllSubCategories` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllSubCategories` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetAllSubCategories`(
	
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT sc.id, sc.cat_id, c.name AS category_name, sc.name AS sub_category_name, sc.slug, sc.is_active
		FROM sub_category AS sc
		INNER JOIN category AS c ON sc.cat_id = c.id;

	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetHomeBanner` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetHomeBanner` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetHomeBanner`()
BEGIN
	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN	
		SELECT 1 AS ResponseCode, 'Home Banner Data !' AS ResponseMessage;	
	
		SELECT * FROM `home_banner` WHERE `is_active` = 1 AND `is_delete` = 0 limit 1;	
	END;
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetProductByCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetProductByCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetProductByCategory`(
	IN SPCategoryID INT
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
	
		SELECT 1 AS ResponseCode, 'Product By Category Data!' AS ResponseMessage;
		
		SELECT p.id, p.name, p.slug, p.image, v.id AS variation_id, v.mrp, v.price, v.qty, cat.name as category_name, p.cat_id
		FROM products AS p
		JOIN (SELECT MIN(id) AS variation_id, product_id FROM variation GROUP BY product_id) AS min_var ON p.id = min_var.product_id
		JOIN variation AS v ON min_var.variation_id = v.id
		JOIN category AS cat ON p.cat_id = cat.id
		WHERE p.is_active = 1 AND p.is_delete = 0 AND p.cat_id = SPCategoryID
		ORDER BY RAND();
	END;
        
        
        IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END if;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetProductById` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetProductById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetProductById`(
	IN SPProductId INT
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
	
		SELECT 1 AS ResponseCode, 'Product By ID Data!' AS ResponseMessage;
		
		select p.id, cat.name as category_name, sc.name as sub_category_name, b.brand_name, p.name as product_name, p.short_description, p.description, p.slug, p.image, p.sku_code, p.hsn_code,p.cod, p.product_weight,
		p.shipping_weight, p.dispatch_time, p.delivery_time, p.packed_by, p.manufactured_by, p.video_link, 
		v.id as variation_id, v.mrp, v.price, v.qty, v.image as variation_image,
		s.size, c.color,
		vi.variation_img
		from products as p 
		join category as cat on p.cat_id = cat.id
		join sub_category as sc on p.sub_cat_id = sc.id
		join brand as b on p.brand_id = b.id
		join variation as v on p.id = v.product_id
		join size as s on v.size_id = s.id
		join color as c on v.color_id = c.id
		join variation_image as vi on v.id = vi.variation_id
		where p.is_active = 1 and p.is_delete = 0 and p.id = SPProductId 
		order by v.id asc;
	END;
        
        
        IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END if;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetProductBySubCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetProductBySubCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetProductBySubCategory`(
	IN SPSubCategoryId INT
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
	
		SELECT 1 AS ResponseCode, 'Product By SubCategory Data!' AS ResponseMessage;
		
		SELECT p.id, p.name, p.slug, p.image, v.id AS variation_id, v.mrp, v.price, v.qty, cat.name as category_name, p.cat_id
		FROM products AS p
		JOIN (SELECT MIN(id) AS variation_id, product_id FROM variation GROUP BY product_id) AS min_var ON p.id = min_var.product_id
		JOIN variation AS v ON min_var.variation_id = v.id
		JOIN category AS cat ON p.cat_id = cat.id
		WHERE p.is_active = 1 AND p.is_delete = 0 AND p.cat_id = SPSubCategoryId
		ORDER BY RAND();
	END;
        
        
        IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END if;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetProductByTag` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetProductByTag` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetProductByTag`(
	in SPTagName varchar(50),
	in SPLimit int
    )
BEGIN
	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	IF SPTagName = 'best_seller' 
	THEN
	
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
	
		SELECT p.id, p.name, p.slug, p.image, v.id AS variation_id, v.mrp, v.price, v.qty
		FROM products AS p
		JOIN  (SELECT MIN(id) AS variation_id, product_id FROM variation GROUP BY product_id) AS min_var ON p.id = min_var.product_id
		JOIN variation AS v ON min_var.variation_id = v.id
		WHERE p.best_seller = 1 AND p.is_active = 1 AND p.is_delete = 0
		ORDER BY RAND()
		LIMIT 20 ;
		
	ELSEIF SPTagName = 'featured_products' 
	THEN
	
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT p.id, p.name, p.slug, p.image, v.id AS variation_id, v.mrp, v.price, v.qty
		FROM products AS p
		JOIN  (SELECT MIN(id) AS variation_id, product_id FROM variation GROUP BY product_id) AS min_var ON p.id = min_var.product_id
		JOIN variation AS v ON min_var.variation_id = v.id
		WHERE p.featured_products = 1 AND p.is_active = 1 AND p.is_delete = 0
		ORDER BY RAND()
		LIMIT 20 ;
		
	ELSEIF SPTagName = 'discounted_products' 
	THEN
			
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
	
		SELECT p.id, p.name, p.slug, p.image, v.id AS variation_id, v.mrp, v.price, v.qty
		FROM products AS p
		JOIN  (SELECT MIN(id) AS variation_id, product_id FROM variation GROUP BY product_id) AS min_var ON p.id = min_var.product_id
		JOIN variation AS v ON min_var.variation_id = v.id
		WHERE p.discounted_products = 1 AND p.is_active = 1 AND p.is_delete = 0
		ORDER BY RAND()
		LIMIT 20 ;
		
	ELSEIF SPTagName = 'new_arrival' 
	THEN
	
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT p.id, p.name, p.slug, p.image, v.id AS variation_id, v.mrp, v.price, v.qty
		FROM products AS p
		JOIN  (SELECT MIN(id) AS variation_id, product_id FROM variation GROUP BY product_id) AS min_var ON p.id = min_var.product_id
		JOIN variation AS v ON min_var.variation_id = v.id
		WHERE p.new_arrival = 1 AND p.is_active = 1 AND p.is_delete = 0
		ORDER BY RAND()
		LIMIT 20 ;
	END IF;
	
        IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetProductReview` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetProductReview` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetProductReview`(
	in SPProductID int	
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		BEGIN
			GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
		END;
		
		begin
			SELECT 1 AS ResponseCode, 'Product Review Data!' AS ResponseMessage;
			
			select r.*, u.name
			from review as r
			join userdata as u on r.user_id = u.id
			where r.product_id = SPProductID;
			
		End;
		
		IF custom_error_message IS NOT NULL THEN
		
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
						
		END IF;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `GetSubCategories` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetSubCategories` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetSubCategories`(
	in SPCategoryId int
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		Select * from `sub_category` where cat_id = SPCategoryId and is_active = 1 and is_delete = 0;
	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetUserActivityCounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetUserActivityCounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetUserActivityCounts`(
	in SPUserId varchar(50)
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	BEGIN
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		SELECT
			(SELECT COUNT(id) FROM cart WHERE user_id = SPUserId) AS cart_count,
			(SELECT COUNT(id) FROM wishlist WHERE user_id = SPUserId) AS wishlist_count,
			(SELECT COUNT(id) FROM `order` WHERE user_id = SPUserId AND order_status = 3) AS complete_order_count,
			(SELECT COUNT(id) FROM `order` WHERE user_id = SPUserId AND order_status IN (0, 1, 2)) AS pending_order_count;

	END;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `GetUserCartItems` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetUserCartItems` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetUserCartItems`(
	in SPUserID varchar(100)
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		begin
		     GET DIAGNOSTICS CONDITION 1
		     custom_error_message = MESSAGE_TEXT;
		end;
		
		begin
		
			select 1 as ResponseCode, 'User Cart Data' as ResponseMessage;
		
			select
			cart.id AS cart_id,
			cart.product_id as product_id,
			cart.variation_id as variation_id,
			cart.qty AS cart_qty,
			p.name AS product_name,
			p.image AS product_image,
			p.short_description AS product_description,
			p.gst as product_gst,
			p.cod as cod,
			p.product_weight,
			p.shipping_weight,
			v.size_id as size_id,
			v.color_id as color_id,	
			c.color as product_color,					
			v.mrp AS product_mrp,
			v.price AS product_price,
			s.size AS product_size
			FROM `cart` AS cart
			JOIN `products` AS p ON cart.product_id = p.id
			JOIN `variation` AS v ON cart.`variation_id` = v.id
			JOIN size AS s ON v.size_id = s.id
			join color as c on v.color_id = c.id
			WHERE cart.user_id = SPUserID;			
		end;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		end if;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `GetUserOrderData` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetUserOrderData` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetUserOrderData`(
	in SPUserID int
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		begin
		     GET DIAGNOSTICS CONDITION 1
		     custom_error_message = MESSAGE_TEXT;
		end;
		
		begin
		
			select 1 as ResponseCode, 'User Order Data' as ResponseMessage;
		
			select o.id, o.payment_id, o.total_amount, o.gst, o.shipping, o.order_status,o.order_cancel,o.tracking_id, o.courier_name,o.created_at as order_date,
			item.productid, item.qty, item.variation_id,
			v.size_id, v.color_id, v.mrp, v.price,
			c.color, s.size,
			p.name as product_name, p.image as product_image
			
			 from `order` as o	
			 join order_items as item on o.id = item.orderid
			 join variation as v on item.variation_id = v.id
			 join color as c on v.color_id = c.id
			 join size as s on v.size_id = s.id
			 join products as p on item.productid = p.id 
			 where o.user_id = SPUserID;
		end;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		end if;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `GetWishlistItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetWishlistItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `GetWishlistItem`(
	IN SPUserID varchar(20)
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		BEGIN
		     GET DIAGNOSTICS CONDITION 1
		     custom_error_message = MESSAGE_TEXT;
		END;
		
		BEGIN
		
			SELECT 1 AS ResponseCode, 'User Wishlist Data' AS ResponseMessage;
		
			SELECT
			w.id AS wishlist_id,
			w.qty AS wishlist_qty,
			p.id AS product_id,
			p.name AS product_name,
			p.image AS product_image,
			p.short_description AS product_description,
			v.mrp AS product_mrp,
			v.price AS product_price,
			s.size AS product_size,
			cat.name as product_category
			FROM `wishlist` AS w
			JOIN `products` AS p ON w.product_id = p.id
			JOIN `variation` AS v ON w.`variation_id` = v.id
			JOIN size AS s ON v.size_id = s.id
			join category as cat on p.cat_id = cat.id
			WHERE w.user_id = SPUserID;			
		END;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		END IF;

END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertAddress` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertAddress` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertAddress`(
	IN SPUserid int,
	IN SPName VARCHAR(50),
	IN SPPhone BIGINT(15),
	IN SPHouseNo VARCHAR(20),
	IN SPArea varchar(100),
	IN SPLankmark varchar(100),
	in SPCity varchar(50),
	in SPState varchar(50),
	in SPCountry varchar(50),
	in SPZipCode int
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    DECLARE encrypted_password VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
        INSERT INTO address (user_id, phone, name, house, area, landmark, pincode, city, state, country)
        VALUES(SPUserid, SPPhone, SPName, SPHouseNo, SPArea, SPLankmark, SPZipCode, SPCity, SPState, SPCountry);     
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Address Added Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertCartItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertCartItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertCartItem`(
	in SPProductId int,
	in SPVariarionID int,
	in SPQty int,
	in SPUserId varchar(50)
	
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		BEGIN
			GET DIAGNOSTICS CONDITION 1
			custom_error_message = MESSAGE_TEXT;
		END;
		
		begin
			insert into `cart` (product_id, variation_id, qty, user_id)
			values(SPProductId, SPVariarionID, SPQty, SPUserId);
		End;
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		ELSE
			SELECT 1 AS ResponseCode, 'Add To Cart Successfully!' AS ResponseMessage;
			
			select count(id) as cartItem from cart where user_id = SPUserId;
		END IF;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertCategory`(
	SPName varchar(256),
	SPSlug Varchar(250),
	SPImage Text,
	SPStatus int
	)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
           GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    
     DECLARE CONTINUE HANDLER FOR 1062
        BEGIN
           SET custom_error_message = 'Category already exists.';
        END; 

    BEGIN
    
        INSERT INTO `category` (`name`,`slug`,`cat_image`,`is_active`)
        values(SPName, SPSlug, SPImage, SPStatus);
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Category Insert Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertColor` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertColor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertColor`(
	SPColor varchar(256),
	SPStatus int
	)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
           GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    
     DECLARE CONTINUE HANDLER FOR 1062
        BEGIN
           SET custom_error_message = 'Color already exists.';
        END; 

    BEGIN
    
        INSERT INTO `color` (`color`, `is_active`)
        values(SPColor, SPStatus);
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Color Add Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertSize` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertSize` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertSize`(
	SPSize varchar(256),
	SPStatus int
	)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
           GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    
     DECLARE CONTINUE HANDLER FOR 1062
        BEGIN
           SET custom_error_message = 'Size already exists.';
        END; 

    BEGIN
    
        INSERT INTO `size` (`size`, `is_active`)
        values(SPSize, SPStatus);
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Size Add Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertSubCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertSubCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertSubCategory`(
	in SPCat_id int,
	in SPName varchar(256),
	IN SPSlug varchar(250),
	in SPStatus int
	)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
           GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    
     DECLARE CONTINUE HANDLER FOR 1062
        BEGIN
           SET custom_error_message = 'Sub Category already exists.';
        END; 

    BEGIN
    
        INSERT INTO `sub_category` (`cat_id`,`name`,`slug`,`is_active`)
        values(SPCat_id, SPName, SPSlug, SPStatus);
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Sub Category Create Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertUserData` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertUserData` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertUserData`(
	IN SPName VARCHAR(50),
	IN SPEmail VARCHAR(100),
	IN SPPhone BIGINT(20),
	IN SPPassword VARCHAR(50),
	IN SPReferral_code INT,
	IN SPSponsored_by INT
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    DECLARE encrypted_password VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1
            custom_error_message = MESSAGE_TEXT;
        END;

    
    SET encrypted_password = MD5(SPPassword);

    BEGIN
    
        INSERT INTO userdata (NAME, email, phone, PASSWORD, referral_code, sponsored_by)
        VALUES(SPName, SPEmail, SPPhone, encrypted_password, SPReferral_code, SPSponsored_by);     
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Account Created Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `InsertWishlistItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `InsertWishlistItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `InsertWishlistItem`(
	IN SPProductId INT,
	IN SPVariarionID INT,
	IN SPQty INT,
	IN SPUserId varchar(50)
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		BEGIN
			GET DIAGNOSTICS CONDITION 1
			custom_error_message = MESSAGE_TEXT;
		END;
		
		BEGIN
			INSERT INTO `wishlist` (product_id, variation_id, qty, user_id)
			VALUES(SPProductId, SPVariarionID, SPQty, SPUserId);
		END;
		
		
		IF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		ELSE
			SELECT 1 AS ResponseCode, 'Item Add To Wishlist Successfully!' AS ResponseMessage;
			
			SELECT COUNT(id) AS wishlist_count FROM `wishlist` WHERE user_id = SPUserId;
		END IF;
END */$$
DELIMITER ;

/* Procedure structure for procedure `OrderCancel` */

/*!50003 DROP PROCEDURE IF EXISTS  `OrderCancel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `OrderCancel`(	
	in SPReason text,
	in SPOrderId Int
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
        UPDATE `order` SET order_status = '4', order_cancel_reason = SPReason WHERE `id` = SPOrderId;

		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Order Cancel Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `SelectAddressByUserID` */

/*!50003 DROP PROCEDURE IF EXISTS  `SelectAddressByUserID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `SelectAddressByUserID`(
	In SPUserId int
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	Begin
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		select * from `address` where `user_id` = SPUserId and `is_active` = 1;
	End;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `SelectDefaultUserAddress` */

/*!50003 DROP PROCEDURE IF EXISTS  `SelectDefaultUserAddress` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `SelectDefaultUserAddress`(
	In SPUserId int
)
BEGIN

	DECLARE custom_error_message VARCHAR(255);	
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	
	BEGIN
		GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
	END;
	
	Begin
		SELECT 1 AS ResponseCode, 'Records!' AS ResponseMessage;
		
		select * from `address` where `user_id` = SPUserId and active_status = 1 and `is_active` = 1;
	End;
	
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;	

END */$$
DELIMITER ;

/* Procedure structure for procedure `SetDefaultAddress` */

/*!50003 DROP PROCEDURE IF EXISTS  `SetDefaultAddress` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `SetDefaultAddress`(	
	in SPAddressId int,
	in SPUserId int
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
         UPDATE `address` SET active_status = CASE
		WHEN id = SPAddressId THEN 1 
		ELSE 0
		END
         WHERE user_id = SPUserId;
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Address Set To Default Successfully !' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `ToggleStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `ToggleStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `ToggleStatus`(	
	in SPId int,
	IN SPStatus int,
	in SPTableName varchar(256)
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;  

	BEGIN
		SET @sql = CONCAT('UPDATE ', SPTableName, ' SET is_active = ', SPStatus, ' WHERE id = ', SPId);
		PREPARE stmt FROM @sql;
		EXECUTE stmt;
		DEALLOCATE PREPARE stmt;
	END;    
    
    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Status Update Successfully' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateAddress` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateAddress` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdateAddress`(	
	in SPAddressId int,
	IN SPName VARCHAR(50),
	IN SPPhone BIGINT(15),
	IN SPHouseNo VARCHAR(20),
	IN SPArea varchar(100),
	IN SPLankmark varchar(100),
	in SPCity varchar(50),
	in SPState varchar(50),
	in SPCountry varchar(50),
	in SPZipCode int
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    DECLARE encrypted_password VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
        Update address set `phone` = SPPhone, `name` = SPName, `house` = SPHouseNo, `area` = SPArea, `landmark` = SPLankmark, `pincode` = SPZipCode, `city` = SPCity, `state` = SPState, `country` = SPCountry where `id` = SPAddressId;
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Address Update Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateCartQuantity` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateCartQuantity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdateCartQuantity`(
	in SPQty int,
	in SPCartId int
)
BEGIN
		DECLARE custom_error_message VARCHAR(255);
		DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
		
		BEGIN
			GET DIAGNOSTICS CONDITION 1
			custom_error_message = MESSAGE_TEXT;
		END;
		
		BEGIN
			update `cart` set qty = SPQty where id = SPCartId;
		END;
		
		iF custom_error_message IS NOT NULL THEN
			SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
		ELSE
			SELECT 1 AS ResponseCode, 'Quantity Update Successfully!' AS ResponseMessage;
		END IF;

	END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdateCategory`(	
	in SPName varchar(256),
	in SPSlug varchar(250),
	in SPImage text,
	in SPCat_id int
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    if SPImage is not null then
        Update `category` set `name` = SPName, `slug` = SPSlug, `cat_image` = SPImage where `id` = SPCat_id;
        else
        Update `category` set `name` = SPName, `slug` = SPSlug where `id` = SPCat_id;
	END IF;	
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Category Update Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateColor` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateColor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdateColor`(    
    IN SPColorId INT,
    IN SPColor VARCHAR(256),
    IN SPStatus INT
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
        UPDATE `color` SET `color` = SPColor, `is_active` = SPStatus WHERE `id` = SPColorId;

        IF custom_error_message IS NOT NULL THEN
            SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
        ELSE
            SELECT 1 AS ResponseCode, 'Color Update Successfully!' AS ResponseMessage;
        END IF;
        
    END;

END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateOrderStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateOrderStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdateOrderStatus`(	
	in SPOrderId int,
	IN SPStatusId int
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    DECLARE encrypted_password VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
        Update `order` set `order_status` = SPStatusId where `id` = SPOrderId;
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Order Status Change Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdatePaymentId` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdatePaymentId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdatePaymentId`(	
	in SPOrderId int,
	IN SPPaymentId VARCHAR(256)
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    DECLARE encrypted_password VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
        Update `order` set `payment_id` = SPPaymentId, `order_status` = 1 where `id` = SPOrderId;
		
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'PaymentID Update Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateSize` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateSize` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdateSize`(    
    IN SPSizeId INT,
    IN SPSize VARCHAR(256),
    IN SPStatus INT
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
    
        UPDATE `size` SET `size` = SPSize, `is_active` = SPStatus WHERE `id` = SPSizeId;

        IF custom_error_message IS NOT NULL THEN
            SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
        ELSE
            SELECT 1 AS ResponseCode, 'Record Update Successfully!' AS ResponseMessage;
        END IF;
        
    END;

END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateSubCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateSubCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UpdateSubCategory`(	
	IN SPSubCat_id INT,
	IN SPCat_id INT,
	in SPName varchar(256),
	in SPSlug varchar(250),
	in SPStatus int
	
)
BEGIN

    DECLARE custom_error_message VARCHAR(255);
    
     DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;    

    BEGIN
	UPDATE `sub_category` SET `cat_id` = SPCat_id, `name` = SPName, `slug` = SPSlug, `is_active` = SPStatus  WHERE `id` = SPSubCat_id;
    END;

    IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
    ELSE
        SELECT 1 AS ResponseCode, 'Sub-Category Update Successfully!' AS ResponseMessage;
    END IF;
    
    
END */$$
DELIMITER ;

/* Procedure structure for procedure `UserLogin` */

/*!50003 DROP PROCEDURE IF EXISTS  `UserLogin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `UserLogin`(
	IN SPEmail VARCHAR(50),
	iN SPPassword VARCHAR(50),
	in SPSessionId varchar(100)
)
BEGIN
	DECLARE user_count INT;
	DECLARE encrypted_password VARCHAR(255);
	DECLARE custom_error_message VARCHAR(255);
		
	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1
            custom_error_message = MESSAGE_TEXT;
        END;
		
	SET encrypted_password = MD5(SPPassword);
	
	begin	
		SELECT COUNT(*) INTO user_count FROM `userdata` WHERE `email` = SPEmail AND `password` = encrypted_password;
	
		IF user_count > 0 THEN
			SELECT 1 AS ResponseCode, 'login success' AS ResponseMessage;
			SELECT * FROM `userdata` WHERE `email` = SPEmail;
			
			if SPSessionId is not null then
				select `id` into @userid from `userdata` where `email` = SPEmail;
				update `cart` set `user_id` = @userid where `user_id` = SPSessionId;
				Update `wishlist` set `user_id` = @userid where `user_id` = SPSessionId;
			end if;
			
		ELSE
			SELECT 0 AS ResponseCode, 'User Not Exist!' AS ResponseMessage;
		END IF;
	End;
	
	IF custom_error_message IS NOT NULL THEN
		SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
	END IF;
			
END */$$
DELIMITER ;

/* Procedure structure for procedure `WishlistToCart` */

/*!50003 DROP PROCEDURE IF EXISTS  `WishlistToCart` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`zordik_user`@`%` PROCEDURE `WishlistToCart`(
    IN SPWishlistId INT,
    in SPUserId varchar(50)
)
BEGIN
    DECLARE custom_error_message VARCHAR(255);

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
        BEGIN
            GET DIAGNOSTICS CONDITION 1 custom_error_message = MESSAGE_TEXT;
        END;   

	-- Insert wishlist items into cart table with the obtained wishlistid
	INSERT INTO `cart` (`product_id`, `variation_id`, `qty`, `user_id`)
	SELECT `product_id`, `variation_id`, `qty`, `user_id`
	FROM `wishlist`
	WHERE `id` = SPWishlistId;

	-- Delete Wishlist Item
	DELETE FROM `wishlist` WHERE `id` = SPWishlistId;

     -- Check for errors
     IF custom_error_message IS NOT NULL THEN
        SELECT 0 AS ResponseCode, custom_error_message AS ResponseMessage;
     ELSE
        SELECT 1 AS ResponseCode, 'Product Move To Cart Successfully!' AS ResponseMessage;
        select
        (SELECT COUNT(id) FROM `wishlist` WHERE user_id = SPUserId) AS wishlist_count,     
        (SELECT COUNT(id) FROM `cart` WHERE user_id = SPUserId) AS cart_count;
     END IF;
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
