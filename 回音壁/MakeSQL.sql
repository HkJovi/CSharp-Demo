use master
go
drop database zrxx
go

use master
go
/*==============================================================*/
/* Database: zrxx                                               */
/*==============================================================*/
create database zrxx
go

use zrxx
go

/*==============================================================*/
/* Table: t_hf                                                  */
/*==============================================================*/
create table t_hf (
   hfid                 int                  identity,
   xjid                 int                  null,
   hfr                  nvarchar(20)         null,
   hfsj                 datetime             null default getdate(),
   hfnr                 ntext                null,
   hfip                 nvarchar(40)         null,
   zjbz                 nvarchar(1)          null,
   hfpj                 nvarchar(255)        null,
   hfpf                 int                  null,
   pjsj                 datetime             null,
   pjip                 nvarchar(40)         null,
   hfbz                 nvarchar(255)        null,
   zjfrom               nvarchar(20)         null,
   zjhfr                nvarchar(20)         null,
   zjhfjb               int                  null,
   hftxt                nvarchar(255)        null,
   constraint PK_T_HF primary key (hfid)
)
go

/*==============================================================*/
/* Table: t_jb                                                  */
/*==============================================================*/
create table t_jb (
   jbid                 int                  identity,
   jbmc                 nvarchar(20)         null,
   jbqx                 nvarchar(255)        null,
   pjbid                int                  null,
   constraint PK_T_JB primary key (jbid)
)
go

/*==============================================================*/
/* Table: t_lb                                                  */
/*==============================================================*/
create table t_lb (
   lbid                 int                  identity,
   lbmc                 nvarchar(20)         null,
   lbbz                 nvarchar(255)        null,
   plbid                int                  null,
   constraint PK_T_LB primary key (lbid)
)
go

/*==============================================================*/
/* Table: t_log                                                 */
/*==============================================================*/
create table t_log (
   logid                bigint               identity,
   optmc                nvarchar(20)         null,
   optsj                datetime             null default getdate(),
   optip                nvarchar(40)         null,
   opturl               nvarchar(255)        null,
   optsm                nvarchar(255)        null,
   constraint PK_T_LOG primary key (logid)
)
go

/*==============================================================*/
/* Table: t_lx                                                  */
/*==============================================================*/
create table t_lx (
   lxmc                 nvarchar(20)         not null,
   lximg                nvarchar(255)        null,
   lxpx                 int                  null,
   constraint PK_T_LX primary key (lxmc)
)
go

/*==============================================================*/
/* Table: t_mb                                                  */
/*==============================================================*/
create table t_mb (
   mbid                 int                  identity,
   udm                  nvarchar(20)         null,
   mbmc                 nvarchar(20)         null,
   mbnr                 ntext                null,
   constraint PK_T_MB primary key (mbid)
)
go

/*==============================================================*/
/* Table: t_qx                                                  */
/*==============================================================*/
create table t_qx (
   qxid                 int                  identity,
   qxmc                 nvarchar(20)         null,
   qxbz                 nvarchar(255)        null,
   qxpx                 int                  null,
   constraint PK_T_QX primary key (qxid)
)
go

/*==============================================================*/
/* Table: t_qxz                                                 */
/*==============================================================*/
create table t_qxz (
   zid                  int                  identity,
   zmc                  nvarchar(20)         null,
   zqx                  nvarchar(255)        null,
   constraint PK_T_QXZ primary key (zid)
)
go

/*==============================================================*/
/* Table: t_set                                                 */
/*==============================================================*/
create table t_set (
   k                    nvarchar(40)         not null,
   v                    nvarchar(3000)       null,
   constraint PK_T_SET primary key (k)
)
go

/*==============================================================*/
/* Table: t_user                                                */
/*==============================================================*/
create table t_user (
   udm                  nvarchar(20)         not null,
   jbid                 int                  null,
   pwd                  nvarchar(20)         null,
   uxm                  nvarchar(20)         null,
   umc                  nvarchar(40)         null,
   upx                  int                  null,
   uzt                  nvarchar(1)          null,
   ubz                  nvarchar(255)        null,
   xrbz                 nvarchar(1)          null,
   zid                  int                  null,
   constraint PK_T_USER primary key (udm)
)
go

/*==============================================================*/
/* Table: t_xj                                                  */
/*==============================================================*/
create table t_xj (
   xjid                 int                  identity,
   dm                   nvarchar(10)         null,
   pwd                  nvarchar(10)         null,
   lbid                 int                  null,
   xm                   nvarchar(20)         null,
   dw                   nvarchar(40)         null,
   sj                   datetime             null default getdate(),
   dz                   nvarchar(80)         null,
   dh                   nvarchar(20)         null,
   bt                   nvarchar(40)         null,
   nr                   ntext                null,
   fj                   nvarchar(255)        null,
   ztdm                 nvarchar(1)          null,
   xdbz                 nvarchar(1)          null,
   hfid                 int                  null,
   lxmc                 nvarchar(20)         null,
   ip                   nvarchar(40)         null,
   zjhfr                nvarchar(20)         null,
   zjhfjb               int                  null,
   pf                   int                  null,
   hits                 int                  null,
   yycs                 int                  null,
   gkbz                 nvarchar(1)          null,
   email                nvarchar(40)         null,
   deluser              nvarchar(20)         null,
   hot                  nvarchar(1)          null,
   constraint PK_T_XJ primary key (xjid)
)
go

/*==============================================================*/
/* Table: t_zt                                                  */
/*==============================================================*/
create table t_zt (
   ztdm                 nvarchar(1)          not null,
   ztmc                 nvarchar(20)         null,
   constraint PK_T_ZT primary key (ztdm)
)
go

/*==============================================================*/
/* View: v_xj                                                   */
/*==============================================================*/
create view v_xj as
select * from t_xj where deluser=''
go

alter table t_hf
   add constraint FK_T_HF_REFERENCE_T_XJ foreign key (xjid)
      references t_xj (xjid)
go

alter table t_hf
   add constraint FK_T_HF_REFERENCE_T_USER foreign key (hfr)
      references t_user (udm)
go

alter table t_mb
   add constraint FK_T_MB_REFERENCE_T_USER foreign key (udm)
      references t_user (udm)
go

alter table t_user
   add constraint FK_T_USER_REFERENCE_T_JB foreign key (jbid)
      references t_jb (jbid)
go

alter table t_user
   add constraint FK_T_USER_REFERENCE_T_QXZ foreign key (zid)
      references t_qxz (zid)
go

alter table t_xj
   add constraint FK_T_XJ_REFERENCE_T_LB foreign key (lbid)
      references t_lb (lbid)
go

alter table t_xj
   add constraint FK_T_XJ_REFERENCE_T_ZT foreign key (ztdm)
      references t_zt (ztdm)
go

alter table t_xj
   add constraint FK_T_XJ_REFERENCE_T_LX foreign key (lxmc)
      references t_lx (lxmc)
go


create procedure MakeInitData as
begin
  
    insert into t_lx(lxpx,lxmc,lximg)values(1,'建议','/zrxx/images/lb101.gif')
    insert into t_lx(lxpx,lxmc,lximg)values(2,'求助','/zrxx/images/lb111.gif')
    insert into t_lx(lxpx,lxmc,lximg)values(3,'投诉','/zrxx/images/lb121.gif')
    insert into t_lx(lxpx,lxmc,lximg)values(4,'咨询','/zrxx/images/lb131.gif')
    insert into t_lx(lxpx,lxmc,lximg)values(5,'其它','/zrxx/images/lb141.gif')
    
    insert into t_zt(ztdm,ztmc)values('1','待处复')
    insert into t_zt(ztdm,ztmc)values('2','待转处')
    insert into t_zt(ztdm,ztmc)values('3','已处复')
    
    insert into t_lb(lbmc,lbbz,plbid)values('所有类别','',-1)
    insert into t_lb(lbmc,lbbz,plbid)values('网络问题','',1)
    insert into t_lb(lbmc,lbbz,plbid)values('一卡通','',1)
    insert into t_lb(lbmc,lbbz,plbid)values('服务态度','',1)
    
    insert into t_jb(jbmc,jbqx,pjbid)values('主任','所有权限',-1)
    insert into t_jb(jbmc,jbqx,pjbid)values('网络部','所有权限',1)
    insert into t_jb(jbmc,jbqx,pjbid)values('一卡通部','所有权限',1)
    insert into t_jb(jbmc,jbqx,pjbid)values('教师部','所有权限',2)
    insert into t_jb(jbmc,jbqx,pjbid)values('学生部','所有权限',2)
    insert into t_jb(jbmc,jbqx,pjbid)values('收费部','所有权限',2)
    
    insert into t_qxz(zmc,zqx)values('所有权限','所有权限')
    
    insert into t_user(upx,xrbz,udm,uxm,umc,jbid)values(1,'1','lf','刘菲','网络中心主任刘菲',1)
    insert into t_user(upx,xrbz,udm,uxm,umc,jbid)values(2,'1','admin','管理员','网络中心信箱管理员',1)
    insert into t_user(upx,xrbz,udm,uxm,umc,jbid)values(3,'1','tq','唐强','网络中心网络部科长唐强',2)
    insert into t_user(upx,xrbz,udm,uxm,umc,jbid)values(4,'0','yxh','叶小花','网络中心网络收费部',6)
    insert into t_user(upx,xrbz,udm,uxm,umc,jbid)values(5,'0','sbz','宋秉政','网络中心网络收费部',6)
    insert into t_user(upx,xrbz,udm,uxm,umc,jbid)values(6,'0','rzw','任政危','一卡通部',3)
    update t_user set pwd='1',uzt='1',ubz='',zid=1
    
    insert into t_mb(udm)select udm from t_user
    update t_mb set mbmc=udm+'的转处模板',mbnr='请转%zjTo%处复' where mbmc is null
    
    insert into t_mb(udm)select udm from t_user
    update t_mb set mbmc=udm+'的回复模板',mbnr='%xm%您好，收到您的来信，领导非常重视，责成我部回复如下：' where mbmc is null
    
    insert into t_qx(qxpx,qxmc)values(0,'所有权限')
    
    insert into t_qx(qxpx,qxmc)values(1,'部门管理')
    insert into t_qx(qxpx,qxmc)values(2,'添加部门')
    insert into t_qx(qxpx,qxmc)values(3,'修改部门')
    insert into t_qx(qxpx,qxmc)values(4,'删除部门')
    
    insert into t_qx(qxpx,qxmc)values(5,'分类管理')
    insert into t_qx(qxpx,qxmc)values(6,'添加分类')
    insert into t_qx(qxpx,qxmc)values(7,'修改分类')
    insert into t_qx(qxpx,qxmc)values(8,'删除分类')
    
    insert into t_qx(qxpx,qxmc)values(9,'类型管理')
    insert into t_qx(qxpx,qxmc)values(10,'添加类型')
    insert into t_qx(qxpx,qxmc)values(11,'修改类型')
    insert into t_qx(qxpx,qxmc)values(12,'删除类型')
    
    insert into t_qx(qxpx,qxmc)values(13,'模板管理')
    insert into t_qx(qxpx,qxmc)values(14,'添加模板')
    insert into t_qx(qxpx,qxmc)values(15,'修改模板')
    insert into t_qx(qxpx,qxmc)values(16,'删除模板')
    
    insert into t_qx(qxpx,qxmc)values(17,'用户管理')
    insert into t_qx(qxpx,qxmc)values(18,'添加用户')
    insert into t_qx(qxpx,qxmc)values(19,'修改用户')
    insert into t_qx(qxpx,qxmc)values(20,'删除用户')
    
    insert into t_qx(qxpx,qxmc)values(21,'查询信件')
    insert into t_qx(qxpx,qxmc)values(22,'处复信件')
    insert into t_qx(qxpx,qxmc)values(23,'修改密码')
    insert into t_qx(qxpx,qxmc)values(24,'删除信件')
    
insert into t_set(k,v)values('AllowUploadFileExts','|.doc|.docx|.xls|.xlsx|.ppt|.pptx|.dbf|.txt|.rar|.zip|.png|.gif|.jpg|.jpeg|.bmp|')
insert into t_set(k,v)values('AllowUploadFileMaxSize','2097152')
insert into t_set(k,v)values('SmtpHost','smtp.163.com')
insert into t_set(k,v)values('SmtpPort','25')
insert into t_set(k,v)values('FromAddress','scmsmj@163.com')
insert into t_set(k,v)values('FromPwd','1122335')
insert into t_set(k,v)values('FromName','网络中心主任信箱')
insert into t_set(k,v)values('EMailSubject','网络中心主任信箱-“{bt}”信件的编码及密码')
insert into t_set(k,v)values('EMailBody','{url}{xm}您好')

insert into t_set(k,v)values('LLS','0');
insert into t_set(k,v)values('TodayLLS','0');
insert into t_set(k,v)values('Now','2012-02-26');


    
    
end
go


exec MakeInitData