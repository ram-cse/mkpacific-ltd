<?php $this->view('header') ?>
<?php if($this->session->flashdata('message')){?>
	<div class="message"><?php echo $this->session->flashdata('message');?></div>
<?php }?>
Hi, <strong><?php echo $username; ?></strong>! You are logged in now. <?php echo anchor('/auth/logout/', 'Logout'); ?><br/>
<a href="<?php echo site_url()."/me" ?>">View Profile <a/>

<br/>
01. <br/>
02. TABs - First TAB: MyGroup <br/>
03. Selectable Control<br/>
04. One button to Open an Modal Form<br/>
05. JQuery Calendar Picker<br/>
06. Display User Avitar<br/>
07. Edit Button let replace avartar pic <br/>
08. All post should have a Title<br/>
09. Display Avitar<br/>
10. Body of post...<br/>
11. ...<br/>
12. ...<br/>
13. ...<br/>
14. ...<br/>
15. ...<br/>


<?php if(count(@$group_owner)>0){?>

<div class="group_list">
<div class="group_type">Groups Created</div>
<div class="D_box flush" id="D_results">
	<div class="D_boxbody">
		<div class="isNotDivided ">
			<div id="groupListContainer" class="D_groupList_large">
				<div class="D_summaryList">
                	
                    <!-- Begin Row Of Group-->
                    <?php foreach($group_owner as $group){?>
					<div class="D_group J_groupHover position_1 first">
                        <div style="font-size: 0.9em;" class="D_image">
                            <a class="omnCamp omngj_sj2b" href="<?php echo site_url("group/view/".$group->sitename);?>">
                            	<?php if($group->avatar==''){?>
                                	<img alt="" src="<?php echo base_url();?>images/noPhoto_180.png" width="150">
                                <?php }else{?>
                                	<img alt="" src="<?php echo base_url().'/assets/groups/pictures/thumb/'.$group->avatar;?>" width="150">
                                <?php }?>
                            </a>
                            <div class="D_metasection D_metasectionNoborder D_metasectionBottom">
                                <a href="<?php echo site_url("group/welcome/edit/".$group->sitename);?>">Manage Group</a><br/>
                                <a href="<?php echo site_url("group/welcome/manage_members/".$group->sitename);?>">Manage Members</a>
                            </div>
                        </div>
                        <div class="D_info">
                            <div class="D_name J_help">
                                <a class="omnCamp omngj_sj2b" href="<?php echo site_url("group/view/".$group->sitename);?>"><?php echo $group->name;?></a>
                            </div>
                            <div class="D_primary">
                                <div class="D_description J_help">
                                    <p><?php echo $group->description;?></p>
                                </div>
                                <div class="D_topicList">
                                    <div id="topicList1">
                                    	<?php if(@$cate_owner_groups[$group->id]){?>
                                        <span class="meetup-topic">
                                        	<?php foreach($cate_owner_groups[$group->id] as $cate){?>
                                            	<a href="<?php echo site_url("group/welcome/cate/$cate->id");?>"><span class="first-word J_onClick topic-info-hover"> <?php echo $cate->name;?></a>
                                            <?php }?>
                                        </span>
                                        <?php }?>
                                    </div> 
                                </div>
                            </div>
                        </div>
                    </div>
                    <?php }?>
                    <!-- End Row Of Group-->
                    
				</div>
			</div>
            
		</div>
	</div>
</div>
</div>
<?php }?>
<?php if(count(@$groups_joiner)>0){?>
<div class="group_list">
<div class="group_type">Groups Joined</div>
<div class="D_box flush" id="D_results">
	<div class="D_boxbody">
		<div class="isNotDivided ">
			<div id="groupListContainer" class="D_groupList_large">
				<div class="D_summaryList">
                	
                    <!-- Begin Row Of Group-->
                    <?php foreach($groups_joiner as $group){?>
					<div class="D_group J_groupHover position_1 first">
                        <div style="font-size: 0.9em;" class="D_image">
                            <a class="omnCamp omngj_sj2b" href="<?php echo site_url("group/view/".$group->sitename);?>">
                            	<?php if($group->avatar==''){?>
                                	<img alt="" src="<?php echo base_url();?>images/noPhoto_180.png" width="150">
                                <?php }else{?>
                                	<img alt="" src="<?php echo base_url().'/assets/groups/pictures/thumb/'.$group->avatar;?>" width="150">
                                <?php }?>
                            </a>
                        </div>
                        <div class="D_info">
                            <div class="D_name J_help">
                                <a class="omnCamp omngj_sj2b" href="<?php echo site_url("group/view/".$group->sitename);?>"><?php echo $group->name;?></a>
                            </div>
                            <div class="D_primary">
                                <div class="D_description J_help">
                                    <p><?php echo $group->description;?></p>
                                </div>
                                <div class="D_topicList">
                                    <div id="topicList1">
                                        <?php if(@$cate_join_groups[$group->id]){?>
                                        <span class="meetup-topic">
                                        	<?php foreach($cate_join_groups[$group->id] as $cate){?>
                                            	<a href="<?php echo site_url("group/welcome/cate/$cate->id");?>"><span class="first-word J_onClick topic-info-hover"> <?php echo $cate->name;?></a>
                                            <?php }?>
                                        </span>
                                        <?php }?>
                                    </div> 
                                </div>
                            </div>
                        </div>
                    </div>
                    <?php }?>
                    <!-- End Row Of Group-->
                    
				</div>
			</div>
            
		</div>
	</div>
</div>
</div>
<?php }?>

<?php $this->view('footer') ?>