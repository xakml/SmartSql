-- 测试环境
-- MySQL 5.7.21
CREATE TABLE `smartsqltestdb`.`user` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '长整型主键,自增',
  `UserName` VARCHAR(50) NULL,
  `Status` SMALLINT NULL,
  PRIMARY KEY (`id`))
COMMENT = 'SmartSql测试用表';
